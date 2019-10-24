using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChatExam.DataAccess;
using ChatExam.Models;
using ChatExam.Services;
using Microsoft.EntityFrameworkCore;

namespace ChatExam.Services
{
    public class RegisterUser : IRegisterUser
    {
        
        public void Register(User user)
        {
            using (var context = new Context())
            {
                //var users = context.Users.ToList();
                var users = context.Users
                    .Include(user => user.Login)
                    .ToList();
                foreach (var userInDb in users)
                {
                    if (!user.Login.Equals(userInDb.Login))
                    {
                        context.Add(user);
                    }
                    else
                    {

                    }
                }
                context.SaveChanges();
            }
        }
    }


}


