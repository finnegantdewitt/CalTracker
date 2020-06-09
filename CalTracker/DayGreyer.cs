using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace CalTracker
{
    [ValueConversion(typeof(int), typeof(bool))]
    public class DayGreyer : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            int month = (int)value;
            FCalendar fcal = (FCalendar)parameter;
            return month == fcal.CurrentMonth;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
