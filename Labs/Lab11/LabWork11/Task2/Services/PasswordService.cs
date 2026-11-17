using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task2.Services
{
    public class PasswordService
    {
        public bool VerifyPassword(string password, string passwordHash)
            => BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}
