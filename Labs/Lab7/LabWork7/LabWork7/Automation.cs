using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace LabWork7
{
    public class Automation
    {
        private static int _count = 0;

        public void Counter()
            => _count++;

        public void PrintCount()
            => MessageBox.Show($"{_count}");
        public void PrintHello(string name)
            => Console.WriteLine($"Привет, {name}");

        public void Message(string message)
        {
            MessageBox.Show(message);
        }
    }
}
