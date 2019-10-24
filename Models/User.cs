using System;
using System.Collections.Generic;
using System.Text;

namespace ChatExam.Models
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<Messenge> Messenges { get; set; } = new List<Messenge>();
    }
}
