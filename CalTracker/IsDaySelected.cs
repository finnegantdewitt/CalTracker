using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace CalTracker
{ 
    [ValueConversion(typeof(DateTime), typeof(bool))]
    public class IsDaySelected : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            DateTime dateTime = (DateTime)value;
            FCalendar fcal = (FCalendar)parameter;
            return dateTime == fcal.SelectedFDay.dateTime;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
