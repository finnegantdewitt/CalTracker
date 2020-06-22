using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;

namespace CalTracker
{
    public class FCalendar : INotifyPropertyChanged
    {
        readonly CultureInfo myCI = new CultureInfo("en-US");
        public Calendar calendar;
        public List<FDay> days;
        private FDay _SelectedFDay;
        private int _CurrentMonth;

        public FCalendar()
        {
            calendar = myCI.Calendar;
            days = LoadFDays(DateTime.Now.Year);
            _CurrentMonth = DateTime.Now.Month;
            _SelectedFDay = getFDay(DateTime.Now.Date);
        }
        private FDay getFDay(DateTime dateTime)
        {
            foreach(FDay fday in days)
            {
                if (fday.dateTime == dateTime)
                    return fday;
            }
            throw new Exception("Error in getFDay");
        }

        private List<FDay> LoadFDays(int year)
        {
            List<FDay> fDays = new List<FDay>();
            int week = 0;
            for (int month = 1; month <= calendar.GetMonthsInYear(year); month++)
            {
                for(int day = 1; day <= calendar.GetDaysInMonth(year, month); day++)
                {
                    FDay fDay = new FDay(year, month, day, week);
                    if (fDay.DayOfWeek == 6)
                    {
                        week++;
                    }
                    fDays.Add(fDay);
                }
            }
            return fDays;
        }

        public ObservableCollection<FDay> MonthView
        {
            get 
            {
                ObservableCollection<FDay> monthList = new ObservableCollection<FDay>();
                (int, int) monthColumnRange = this.monthColumnRange(CurrentMonth);
                foreach (FDay day in days)
                {
                    if ((day.WeekOfYear >= monthColumnRange.Item1) && (day.WeekOfYear <= monthColumnRange.Item2))
                    {
                        day.RowInCalView = day.WeekOfYear - monthColumnRange.Item1;
                        monthList.Add(day);
                    }

                }
                return monthList;
            } 
        }


        private (int, int) monthColumnRange(int month)
        {
            foreach(FDay day in days)
            {
                if(day.Month == month)
                {
                    return (day.WeekOfYear, day.WeekOfYear + 5);
                }
            }
            throw new Exception("Something happened in the MonthColumnRange");
        }

        public string MonthYearTitle
        {
            get { return CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CurrentMonth) + " " + DateTime.Now.Year; }
        }

        public int CurrentMonth
        {
            get
            {
                return _CurrentMonth;
            }
            set
            {
                if(_CurrentMonth != value)
                {
                    _CurrentMonth = value;
                    OnPropertyChanged("MonthYearTitle");
                    OnPropertyChanged("MonthView");
                }
            }
        }

        public FDay SelectedFDay
        {
            get
            {
                return _SelectedFDay; 
            }
            set
            {
                _SelectedFDay = value;
                OnPropertyChanged("MonthView");
                OnPropertyChanged("SelectedFDay");
                OnPropertyChanged("HabitRows");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

    }
}
