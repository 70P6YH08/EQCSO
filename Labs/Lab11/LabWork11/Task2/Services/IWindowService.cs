using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Task2.Services
{
    public interface IWindowService
    {
        void OpenWindow(Window window, Window? lastWindow);
    }
}
