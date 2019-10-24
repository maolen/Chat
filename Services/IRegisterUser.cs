using System;
using System.Collections.Generic;
using System.Text;
using ChatExam.Models;

namespace ChatExam.Services
{
    public interface IRegisterUser
    {
        void Register(User user);
    }
}
