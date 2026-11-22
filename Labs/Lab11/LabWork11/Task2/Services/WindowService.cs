using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Task2.Views;

namespace Task2.Services
{
    public class WindowService : IWindowService
    {
        private Window? _lastWindow;
        public void OpenWindow(Window window, Window? lastWindow)
        {
            if (_lastWindow != null)
            {
                _lastWindow.Show();
                window.Close();
                _lastWindow = window;
            }
            else
            {
                window.Show();
                _lastWindow = lastWindow;
            }
        }
    }
}
