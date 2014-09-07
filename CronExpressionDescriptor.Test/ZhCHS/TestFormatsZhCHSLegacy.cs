using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.ZhCHS
{
    [TestClass]
    [DeploymentItem(@"zh-CHS\CronExpressionDescriptor.resources.dll", "zh-CHS")]
    public class TestFormatsZhCHSLegacy : TestFormatsZhCHSBase
    {
        public TestFormatsZhCHSLegacy()
            : base(FormatsTypeEnum.Legacy)
        {
        }
    }
}