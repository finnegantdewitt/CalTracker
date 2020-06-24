using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace CalTracker
{
    [Serializable]
    public class FDay
    {
        public DateTime DateTime { get; set; }
        public int WeekOfYear { get; set; }
        public int RowInCalView { get; set; }
        public ObservableCollection<HabitRow> DayScore { get; set; } = new ObservableCollection<HabitRow>();
        public FDay() { }
        public FDay(int year, int month, int day, int week)
        {
            DateTime = new DateTime(year, month, day);
            WeekOfYear = week;
            DayScore.Add(new HabitRow("Exercise", 0, 0, Brushes.White));
            DayScore.Add(new HabitRow("Diet", 0, 1, Brushes.Green));
            DayScore.Add(new HabitRow("Programming", 0, 2, Brushes.Purple));
        }
        public int Day
        {
            get
            {
                return DateTime.Day;
            }
        }
        public int Month
        {
            get
            {
                return DateTime.Month;
            }
        }
        public int DayOfWeek
        {
            get
            {
                return (int)DateTime.DayOfWeek;
            }
        }

    }
}
