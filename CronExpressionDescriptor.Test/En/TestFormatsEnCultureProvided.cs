using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.En
{
    [TestClass]
    [DeploymentItem(@"en\CronExpressionDescriptor.resources.dll", "en")]
    public class TestFormatsEnCultureProvided : TestFormatsEnBase
    {
        public TestFormatsEnCultureProvided() : base(FormatsTypeEnum.CultureProvided)
        {
        }

        public override string GetTimeString(int hour, int minute)
        {
            return GetTimeStringAmPmWithoutLeadingZero(hour, minute);
        }

        public override string GetTimeString(int hour, int minute, int second)
        {
            return GetTimeStringAmPmWithoutLeadingZero(hour, minute, second);
        }
    }
}