using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.Fr
{
    [TestClass]
    [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
    public class TestFormatsFrCultureProvided : TestFormatsFrBase
    {
        public TestFormatsFrCultureProvided() : base(FormatsTypeEnum.CultureProvided)
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