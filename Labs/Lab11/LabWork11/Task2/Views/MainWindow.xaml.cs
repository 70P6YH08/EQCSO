using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Task2.Contexts;
using Task2.Services;
using Task2.Views;

namespace Task2.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserService _userService;
        private string userRole = "User";
        public MainWindow(UserService userService)
        {
            InitializeComponent();
            _userService = userService;
        }

        private async Task authorizationButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(loginTextBox.Text))
                MessageBox.Show("Логин пуст", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            if (String.IsNullOrWhiteSpace(passwordTextBox.Text))
                MessageBox.Show("Пароль пуст", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            var user = await _userService.GetUserDataAsync(loginTextBox.Text, passwordTextBox.Text);

            if(user is null)
                MessageBox.Show("Не удалось авторизироваться!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            MessageBox.Show("Вы авторизировались!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            RulesTestWindow rulesTestWindow = new();
            rulesTestWindow.Show();
        }
    }
}