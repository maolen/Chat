using ChatExam.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatExam.DataAccess
{
        public class Context : DbContext
        {
        private readonly string connectionString;

        public Context(string connectionString)
            {
            this.connectionString = connectionString;
            Database.EnsureCreated();
            }

            public DbSet<User> Users { get; set; }
            public DbSet<Messenge> Messenges { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            optionsBuilder.UseSqlServer(connectionString);
            //optionsBuilder.UseSqlServer("Server=A-305-06;Database=ChatExam;Trusted_Connection=true;");
        }
        /* protected override void OnModelCreating(ModelBuilder modelBuilder)
         {      
         }*/
    }
}
   

