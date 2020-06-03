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
        FCalendar fCalendar;
        int month;
        public MainWindow()
        {
            InitializeComponent();
            fCalendar = new FCalendar();
            month = DateTime.Now.Month;

            Binding monthBinding = new Binding("MonthName");
            monthBinding.Source = fCalendar;
            monthTextBlock.SetBinding(TextBlock.TextProperty, monthBinding);

            Binding monthViewBinding = new Binding("MonthView");
            monthViewBinding.Source = fCalendar;
            itemsControl.SetBinding(ItemsControl.ItemsSourceProperty, monthViewBinding);
        }

        private void prevMonthButton_Click(object sender, RoutedEventArgs e)
        {
            fCalendar.CurrentMonth -= 1;
        }

        private void nextMonthButton_Click(object sender, RoutedEventArgs e)
        {
            fCalendar.CurrentMonth += 1;
        }
    }
}
