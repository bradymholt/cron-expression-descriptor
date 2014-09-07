using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.Nl
{
    [TestClass]
    [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
    public class TestFormatsNlCultureProvided : TestFormatsNlBase
    {
        public TestFormatsNlCultureProvided() : base(FormatsTypeEnum.CultureProvided)
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