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
        public async Task<User>? GetUserDataAsync(string login, string password)
        {
            var user = await appDbContext.Users.FirstOrDefaultAsync(u => u.Login == login);

            if (user is null)
                throw new Exception("Такого пользователя не существует");


            var isPasswordValid = passwordService.VerifyPassword(password, user.PasswordHash);

            if(!isPasswordValid)
                throw new Exception("Неверный пароль");

            return user;
        }
    }
}
