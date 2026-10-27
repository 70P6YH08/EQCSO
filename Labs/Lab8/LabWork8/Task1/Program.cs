string password = "password1";

Console.WriteLine("Пользователь: root");
Console.Write("Введите пароль: ");
var inputPassword = Console.ReadLine();
var authorizationMessage = (inputPassword!.Equals(password)) ? "ACCESS_GRANTED" : "ACCESS_DENIED";
Console.WriteLine(authorizationMessage);

namespace World
{
    public class Person
    {
        private string? _name = "Я";

        public void PrintHello()
            => Console.WriteLine($"Привет, {_name}");
    }
}