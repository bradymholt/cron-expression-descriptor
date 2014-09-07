using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.ZhCHS
{
    [TestClass]
    [DeploymentItem(@"zh-CHS\CronExpressionDescriptor.resources.dll", "zh-CHS")]
    public class TestFormatsZhCHSCultureProvided : TestFormatsZhCHSBase
    {
        public TestFormatsZhCHSCultureProvided()
            : base(FormatsTypeEnum.CultureProvided)
        {
        }

        public override string GetTimeString(int hour, int minute)
        {
            return GetTimeString24HoursWithoutLeadingZero(hour, minute);
        }

        public override string GetTimeString(int hour, int minute, int second)
        {
            return GetTimeString24HoursWithoutLeadingZero(hour, minute, second);
        }
    }
}