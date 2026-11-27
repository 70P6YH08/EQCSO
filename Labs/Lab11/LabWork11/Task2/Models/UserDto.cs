using System;
using System.Collections.Generic;
using System.Text;

namespace Task2.Models
{
    public class UserDto
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string Role { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
    }
}
