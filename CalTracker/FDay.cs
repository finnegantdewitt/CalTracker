using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CalTracker
{
    public class FDay : INotifyPropertyChanged
    {
        public DateTime dateTime { get; }
        public Dictionary<string, int> DayScore { get; set; }
        public int Column { get; set; }
        public int WeekOfYear { get; set; }
        public int RowInCalView { get; set; }

        private double _Score;
        
        public FDay(int year, int month, int day)
        {
            dateTime = new DateTime(year, month, day);
            _Score = 0;
        }
        public FDay(int year, int month, int day, int week)
        {
            dateTime = new DateTime(year, month, day);
            WeekOfYear = week;
            Column = DayOfWeek;
            _Score = 0;
        }
        public int Day
        {
            get
            {
                return dateTime.Day;
            }
        }
        public int Month
        {
            get
            {
                return dateTime.Month;
            }
        }
        public int DayOfWeek
        {
            get
            {
                return (int)dateTime.DayOfWeek;
            }
        }
        public override string ToString()
        {
            return " " + Column + " " + WeekOfYear;
        }


        public double Score 
        { 
            get
            {
                return _Score;
            }
            set
            {
                _Score = value;
                OnPropertyChanged("Score");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

    }
}
