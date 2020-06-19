using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly FCalendar fCalendar;
        public MainWindow()
        {
            InitializeComponent();
            fCalendar = (FCalendar)this.FindResource("fCalendar");
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

        private void ExerciseSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider slider = (Slider)sender;
            fCalendar.SelectedFDay.Score = slider.Value;
        }
    }
}
