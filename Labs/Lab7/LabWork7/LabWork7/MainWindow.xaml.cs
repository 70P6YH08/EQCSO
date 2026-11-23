using System.Collections.ObjectModel;
using System.IO;
using System.IO.Pipes;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Task1;
namespace LabWork7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<EventModel> _eventsList = new();
        private readonly EventService _eventService = new();
        private readonly ScriptingHost _scriptingHost;
        private DispatcherTimer _dispatcherTimer;
        private DateTime _currentDateTime;
        public MainWindow()
        {
            InitializeComponent();

            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            _dispatcherTimer.Tick += ExecuteEventTimer_Tick;
            _dispatcherTimer.Start();

            _scriptingHost = new(_eventService);

            Task.Run(async () => await _scriptingHost.Run());

            eventsDataGrid.ItemsSource = _eventsList;
        }


        private async void ExecuteEventTimer_Tick(object? sender, EventArgs e)
        {
            _currentDateTime = DateTime.Now;

            var eventsToExecute = _eventsList
                .Where(e => e.IsExecuted == false && e.StartDateTime <= _currentDateTime)
                .ToList();

            foreach (var eventToExecute in eventsToExecute)
            {
                eventToExecute.IsExecuted = true;

                try
                {
                    await _scriptingHost.ExecuteAsync(eventToExecute.Script);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string code = codeTextBox.Text;
            if(!String.IsNullOrEmpty(code))
                await _scriptingHost.ExecuteAsync(code);
        }

        private void AddEventButton_Click(object sender, RoutedEventArgs e)
        {

            if (!EventStartDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Дата не выбрана", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrWhiteSpace(EventNameTextBox.Text))
            {
                MessageBox.Show("Название пусто", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (String.IsNullOrWhiteSpace(EventScriptTextBox.Text))
            {
                MessageBox.Show("Скрипт пуст", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            TimeSpan.TryParse(EventStartTimeTextBox.Text, out TimeSpan selectedTime);

            var startDateTime = EventStartDatePicker.SelectedDate.Value.Add(selectedTime);



            var newEvent = new EventModel
            {
                Name = EventNameTextBox.Text,
                Description = EventDescriptionTextBox.Text,
                IsExecuted = false,
                StartDateTime = startDateTime,
                Script = EventScriptTextBox.Text,
            };
            _eventService.AddEvent(new EventModel { Name = EventNameTextBox.Text, Description = EventDescriptionTextBox.Text, IsExecuted = false, StartDateTime = startDateTime, Script = EventScriptTextBox.Text });
            _eventsList.Add(newEvent);
            MessageBox.Show("Скрипт успешно добавлен", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}