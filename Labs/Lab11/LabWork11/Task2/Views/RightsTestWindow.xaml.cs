using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Task2.Models;
using Task2.Services;

namespace Task2.Views
{
    /// <summary>
    /// Логика взаимодействия для RulesTestWindow.xaml
    /// </summary>
    public partial class RightsTestWindow : Window
    {
        private readonly UserDto _userDto;
        public RightsTestWindow(UserDto userDto)
        {
            InitializeComponent();
            _userDto = userDto;
        }

        private void Rule1Button_Click(object sender, RoutedEventArgs e)
        {
            ShowInfo();
        }

        private void Rule2Button_Click(object sender, RoutedEventArgs e)
        {
            ShowInfo();
        }

        private void Rule3Button_Click(object sender, RoutedEventArgs e)
        {
            if (_userDto.Role != "User")
                ShowInfo();
            else
                ShowError();
        }

        private void Rule4Button_Click(object sender, RoutedEventArgs e)
        {
            if (_userDto.Role != "User")
                ShowInfo();
            else
                ShowError();
        }

        private void Rule5Button_Click(object sender, RoutedEventArgs e)
        {
            if (_userDto.Role == "Admin")
                ShowInfo();
            else
                ShowError();
        }

        private void Rule6Button_Click(object sender, RoutedEventArgs e)
        {
            if (_userDto.Role == "Admin")
                ShowInfo();
            else
                ShowError();
        }

        private void ShowError()
            => MessageBox.Show("Доступ запрещен", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

        private void ShowInfo()
            => MessageBox.Show("Доступ разрешён", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
