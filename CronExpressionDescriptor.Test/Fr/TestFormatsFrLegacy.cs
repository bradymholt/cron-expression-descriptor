using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.Fr
{
    [TestClass]
    [DeploymentItem(@"fr\CronExpressionDescriptor.resources.dll", "fr")]
    public class TestFormatsFrLegacy : TestFormatsFrBase
    {
        public TestFormatsFrLegacy() : base(FormatsTypeEnum.Legacy)
        {
        }
    }
}