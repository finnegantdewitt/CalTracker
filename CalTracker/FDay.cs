using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace CalTracker
{
    class FDay 
    {
        DateTime dateTime;
        private bool highlighted = false;
        public int Column { get; set; }
        public int WeekOfYear { get; set; }
        public int RowInCalView { get; set; }
        
        public FDay(int year, int month, int day)
        {
            dateTime = new DateTime(year, month, day);
        }
        public FDay(int year, int month, int day, int week)
        {
            dateTime = new DateTime(year, month, day);
            WeekOfYear = week;
            Column = this.DayOfWeek;
        }
        public string Day
        {
            get
            {
                return dateTime.Day.ToString();
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
        public bool Highlight
        {
            get
            {
                return highlighted;
            }
        }
    }
}
