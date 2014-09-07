namespace CronExpressionDescriptor
{
    public class Options
    {
        public static Options Default { get; set; }

        static Options()
        {
            Default = new Options();
        }

        public Options()
        {
            ThrowExceptionOnParseError = true;
            CasingType = CasingTypeEnum.Sentence;
            Verbose = false;
            DayOfWeekStartIndexZero = true;
            FormatsType = FormatsTypeEnum.Legacy;
        }

        public Options(Options source)
        {
            ThrowExceptionOnParseError = source.ThrowExceptionOnParseError;
            CasingType = source.CasingType;
            Verbose = source.Verbose;
            DayOfWeekStartIndexZero = source.DayOfWeekStartIndexZero;
            FormatsType = source.FormatsType;
        }

        public bool ThrowExceptionOnParseError { get; set; }
        public CasingTypeEnum CasingType { get; set; }
        public bool Verbose { get; set; }
        public bool DayOfWeekStartIndexZero { get; set; }
        public FormatsTypeEnum FormatsType { get; set; }
    }
}
