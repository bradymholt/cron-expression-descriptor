using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.PtBR
{
    [TestClass]
    [DeploymentItem(@"pt-BR\CronExpressionDescriptor.resources.dll", "pt-BR")]
    public class TestFormatsPtBrCultureProvided : TestFormatsPtBRBase
    {
        public TestFormatsPtBrCultureProvided() : base(FormatsTypeEnum.CultureProvided)
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