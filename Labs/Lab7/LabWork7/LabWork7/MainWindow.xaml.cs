using System.IO;
using System.IO.Pipes;
using System.Windows;
namespace LabWork7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ScriptingHost _scriptingHost = new();

        public MainWindow()
        {
            InitializeComponent();
            var task = new Task(async () => { await _scriptingHost.Run(); });
        }

        public MainWindow(ScriptingHost scriptingHost)
        {
            _scriptingHost = scriptingHost;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            string code = codeTextBox.Text;
            if(!String.IsNullOrEmpty(code))
                await _scriptingHost.ExecuteAsync(code);
        }
    }
}