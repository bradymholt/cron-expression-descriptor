using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.Tr
{
    [TestClass]
    [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
    public class TestFormatsTrLegacy : TestFormatsTrBase
    {
        public TestFormatsTrLegacy() : base(FormatsTypeEnum.Legacy)
        {
        }
    }
}