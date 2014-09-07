using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.Tr
{
    [TestClass]
    [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
    public class TestFormatsTrCultureProvided : TestFormatsTrBase
    {
        public TestFormatsTrCultureProvided() : base(FormatsTypeEnum.CultureProvided)
        {
        }

        public override string GetTimeString(int hour, int minute)
        {
            return GetTimeString24Hours(hour, minute);
        }

        public override string GetTimeString(int hour, int minute, int second)
        {
            return GetTimeString24Hours(hour, minute, second);
        }
    }
}