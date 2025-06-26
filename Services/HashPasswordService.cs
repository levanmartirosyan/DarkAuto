using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.Services
{
    public class HashPasswordService
    {
        public string HashPassword(string Password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(Password);
            
            return hashedPassword;
        }
    }
}
