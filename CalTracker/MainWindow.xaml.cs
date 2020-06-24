using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;

namespace CalTracker
{
    public partial class MainWindow : Window
    {
        readonly FCalendar fCalendar;
        public MainWindow()
        {
            InitializeComponent();
            fCalendar = (FCalendar)FindResource("fCalendar");
        }

        private void prevMonthButton_Click(object sender, RoutedEventArgs e)
        {
            fCalendar.CurrentMonth -= 1;
        }

        private void nextMonthButton_Click(object sender, RoutedEventArgs e)
        {
            fCalendar.CurrentMonth += 1;
        }

        private void FDayButton_Clicked(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            fCalendar.SelectedFDay = (FDay)button.DataContext;
        }

        private void SaveToDiskButton_Click(object sender, RoutedEventArgs e)
        {
            fCalendar.SaveDays();
        }
    }
}
