using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.No
{
    [TestClass]
    [DeploymentItem(@"no\CronExpressionDescriptor.resources.dll", "no")]
    public class TestFormatsNoLegacy : TestFormatsNoBase
    {
        public TestFormatsNoLegacy() : base(FormatsTypeEnum.Legacy)
        {
        }
    }
}