using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.En
{
    [TestClass]
    [DeploymentItem(@"en\CronExpressionDescriptor.resources.dll", "en")]
    public class TestFormatsEnLegacy : TestFormatsEnBase
    {
        public TestFormatsEnLegacy()
            : base(FormatsTypeEnum.Legacy)
        {
        }
    }
}