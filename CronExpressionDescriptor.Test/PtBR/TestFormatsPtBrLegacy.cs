using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.PtBR
{
    [TestClass]
    [DeploymentItem(@"pt-BR\CronExpressionDescriptor.resources.dll", "pt-BR")]
    public class TestFormatsPtBrLegacy : TestFormatsPtBRBase
    {
        public TestFormatsPtBrLegacy()
            : base(FormatsTypeEnum.Legacy)
        {
        }
    }
}