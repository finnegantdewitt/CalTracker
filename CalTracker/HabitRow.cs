using System;
using System.Windows.Media;

namespace CalTracker
{
    public class HabitRow
    {
        public string Name { get; set; }
        public double Score { get; set; }
        public int Row { get; set; }
        public SolidColorBrush Color { get; set; }
        public HabitRow() { }
        public HabitRow(string name, double score, int row, SolidColorBrush solidColorBrush)
        {
            Name = name;
            Score = score;
            Row = row;
            Color = solidColorBrush;
        }
    }
}
