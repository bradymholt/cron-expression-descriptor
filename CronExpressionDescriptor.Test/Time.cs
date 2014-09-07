namespace CronExpressionDescriptor.Test
{
    public class Time
    {
        private int Hour { get; set; }
        private int Minute { get; set; }
        private int? Second { get; set; }

        public Time(int hour, int minute)
            : this(hour, minute, null)
        {
        }

        public Time(int hour, int minute, int second)
            : this(hour, minute, (int?)second)
        {
        }

        private Time(int hour, int minute, int? second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public string Format(ITimeFormatter formatter)
        {
            return Second.HasValue
                ? formatter.GetTimeString(Hour, Minute, Second.Value)
                : formatter.GetTimeString(Hour, Minute);
        }
    }
}