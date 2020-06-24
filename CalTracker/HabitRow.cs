using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Media;


namespace CalTracker
{
    public class HabitRow
    {
        public string Name { get; set; }
        public double Score { get; set; }
        public int Row { get; set; }
        public string ColorInARGB { get; set; }
        public HabitRow() { }
        public HabitRow(string name, double score, int row, SolidColorBrush solidColorBrush)
        {
            Name = name;
            Score = score;
            Row = row;
            Color = solidColorBrush;
        }
        //Work around to make SolidColorBrush Serializable
        [JsonIgnore]
        public SolidColorBrush Color
        {
            get
            {
                var ColorBrush = new SolidColorBrush();
                return ColorBrush.FromARGB(ColorInARGB);
            }
            set
            {
                ColorInARGB = value.ToARGB();
            }
        }
    }
}
