using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.Es
{
    [TestClass]
    [DeploymentItem(@"es\CronExpressionDescriptor.resources.dll", "es")]
    public class TestFormatsEsLegacy : TestFormatsEsBase
    {
        public TestFormatsEsLegacy() : base(FormatsTypeEnum.Legacy)
        {
        }
    }
}