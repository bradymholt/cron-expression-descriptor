using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.Es
{
    [TestClass]
    [DeploymentItem(@"es\CronExpressionDescriptor.resources.dll", "es")]
    public class TestFormatsEsCultureProvided : TestFormatsEsBase
    {
        public TestFormatsEsCultureProvided() : base(FormatsTypeEnum.CultureProvided)
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