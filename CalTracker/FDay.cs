using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CalTracker
{
    public class HabitRow
    {
        public string Name { get; set; }
        public double Score { get; set; }
        public int Row { get; set; }
        public HabitRow(string name, double score, int row)
        {
            Name = name;
            Score = score;
            Row = row;
        }
    }
    public class FDay : INotifyPropertyChanged

    {
        public DateTime dateTime { get; }
        public int Column { get; set; }
        public int WeekOfYear { get; set; }
        public int RowInCalView { get; set; }

        //private Dictionary<string, double> _DayScore = new Dictionary<string, double>();
        private ObservableCollection<HabitRow> _DayScore = new ObservableCollection<HabitRow>();
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
            _DayScore.Add(new HabitRow("Exercise", 0, 0));
            _DayScore.Add(new HabitRow("Diet", 0, 1));
            _DayScore.Add(new HabitRow("Programming", 0, 2));
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

        
        public ObservableCollection<HabitRow> DayScore
        {
            get
            {
                return _DayScore;
            }
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
