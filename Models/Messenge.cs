using System;
using System.Collections.Generic;
using System.Text;

namespace ChatExam.Models
{
    public class Messenge : Entity
    {
        public string Text { get; set; }
        public User User { get; set; }
    }
}
