using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Task2.Contexts;
using Task2.Models;

namespace Task2.Services
{
    public class UserService(AppDbContext appDbContext, PasswordService passwordService)
    {
        public async Task<UserDto>? GetUserDataAsync(string login, string password)
        {
            var user = await appDbContext.Users
                .Where(u => u.Login == login)
                .Select(u => new UserDto
                {
                    Login = u.Login,
                    Name = u.Name,
                    Age = u.Age,
                    Role = u.Role.Name,
                    PasswordHash = u.PasswordHash
                })
                .FirstOrDefaultAsync()
                ?? throw new Exception("Такого пользователя не существует");

            var isPasswordValid = passwordService.VerifyPassword(password, user.PasswordHash);

            if(!isPasswordValid)
                throw new Exception("Неверный пароль");

            return user;
        }
    }
}
