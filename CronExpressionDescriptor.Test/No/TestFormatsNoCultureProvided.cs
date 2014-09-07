using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.No
{
    [TestClass]
    [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
    public class TestFormatsNoCultureProvided : TestFormatsNoBase
    {
        public TestFormatsNoCultureProvided() : base(FormatsTypeEnum.CultureProvided)
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