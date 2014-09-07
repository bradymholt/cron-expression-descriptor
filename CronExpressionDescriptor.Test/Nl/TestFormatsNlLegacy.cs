using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.Nl
{
    [TestClass]
    [DeploymentItem(@"nl\CronExpressionDescriptor.resources.dll", "nl")]
    public class TestFormatsNlLegacy : TestFormatsNlBase
    {
        public TestFormatsNlLegacy() : base(FormatsTypeEnum.Legacy)
        {
        }
    }
}