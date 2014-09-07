namespace CronExpressionDescriptor.Test
{
    public interface ITimeFormatter
    {
        string GetTimeString(int hour, int minute);
        string GetTimeString(int hour, int minute, int second);
    }
}