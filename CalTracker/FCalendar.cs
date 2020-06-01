using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CalTracker
{
    class FCalendar 
    {
        readonly CultureInfo myCI = new CultureInfo("en-US");
        public Calendar calendar;
        readonly DateTime now = DateTime.Now;
        public List<FDay> days;

        public FCalendar()
        {
            calendar = myCI.Calendar;
            days = LoadFDays(now.Year);
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
                    Console.Write(fDay.ToString() + ", ");
                    if (fDay.DayOfWeek == 6)
                    {
                        week++;
                        Console.WriteLine();
                    }
                    fDays.Add(fDay);
                }
            }
            return fDays;
        }
        public List<FDay> MonthView(int month)
        {
            List<FDay> monthList = new List<FDay>();
            (int, int) monthColumnRange = MonthColumnRange(month);
            foreach(FDay day in days)
            {
                if ((day.WeekOfYear >= monthColumnRange.Item1) && (day.WeekOfYear <= monthColumnRange.Item2))
                {
                    day.RowInCalView = day.WeekOfYear - monthColumnRange.Item1;
                    monthList.Add(day);
                }
                    
            }
            return monthList;
        }
        //TODO:
        //add error for out of range for calendar
        //scollable by row/(week)
        private (int, int) MonthColumnRange(int month)
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
    }
}
