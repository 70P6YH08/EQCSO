using Microsoft.Win32;
using System.Security.Principal;
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

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isAdmin = false;

        public MainWindow()
        {
            InitializeComponent();
            GetCurrentUserData();
        }

        private void GetCurrentUserData()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                var windowsPrincipal = new WindowsPrincipal(identity);

                if (!String.IsNullOrWhiteSpace(windowsPrincipal.Identity.Name))
                {
                    var fullName = windowsPrincipal.Identity.Name.Split("\\");
                    domaineTextBox.Text = fullName[0];
                    userNameTextBox.Text = fullName[1];
                    isAuthenticatedTextBox.Text = windowsPrincipal.Identity.IsAuthenticated.ToString();

                    isUserTextBox.Text = windowsPrincipal.IsInRole(WindowsBuiltInRole.User) == true ? "Да" : "Нет";
                    isAdminTextBox.Text = windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator) == true ? "Да" : "Нет";

                    if(windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator))
                        _isAdmin = true;
                }
            }
        }

        private void OpenSystemFolderButton1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Доступ разрешён", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OpenSystemFolderButton2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Доступ разрешён", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void OpenSystemFolderButton3_Click(object sender, RoutedEventArgs e)
        {
            ShowMessage();
        }

        private void OpenSystemFolderButton4_Click(object sender, RoutedEventArgs e)
        {
            ShowMessage();
        }

        private void ShowMessage()
        {
            if (!_isAdmin)
                MessageBox.Show("Доступ запрещен", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                MessageBox.Show("Доступ разрешён", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}