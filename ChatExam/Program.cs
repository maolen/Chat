using ChatExam.DataAccess;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using ChatExam.Services;
using ChatExam.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ChatExam
{
    class Program
    {
        static void Main(string[] args)
        {
            //var builder = new ConfigurationBuilder()
            //                .SetBasePath(Directory.GetCurrentDirectory())
            //                .AddJsonFile("appsetings.json", false, true);

            //IConfigurationRoot configurationRoot = builder.Build();
            //var connectionString = configurationRoot.GetConnectionString("DebugConnectionString");

            // RegisterUser();
            using (var context = new Context())
            {
                var users = context.Users
                    .ToList();
                var messeges = context.Messenges.ToList();
                Console.WriteLine("Логин:");
                var user = new User();
                user.Login = Console.ReadLine();
                Console.WriteLine("Сообщение:");
                var messege = new Messenge();
                messege.Text = Console.ReadLine();
                user.Messenges.Add(messege);
                context.SaveChanges();

                foreach (var userInDb in users)
                {
                    if (!user.Login.Equals(userInDb.Login))
                    {
                        context.Add(user);
                    }
                }
                
                //var result = context.Messenges.ToList();
                foreach (var messegeInDb in messeges.OrderBy(x => x.CreationDate))
                {
                    Console.WriteLine($"{messegeInDb.User.Login}: {messegeInDb.Text}");
                }
                context.SaveChanges();
            }

        }
    }
}
