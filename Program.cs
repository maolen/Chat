using ChatExam.DataAccess;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using ChatExam.Services;

namespace ChatExam
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsetings.json", false, true);

            IConfigurationRoot configurationRoot = builder.Build();
            var connectionString = configurationRoot.GetConnectionString("DebugConnectionString");

            //Console.WriteLine("Логин:");
           // RegisterUser();
            using (var context = new Context(connectionString))
            {
                var result = context.Messenges.ToList();
                context.SaveChanges();
            }

        }
    }
}
