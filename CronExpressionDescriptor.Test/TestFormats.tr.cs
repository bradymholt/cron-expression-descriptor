using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Globalization;
using System.IO;

namespace CronExpressionDescriptor.Test
{
    [TestClass]
    public class TestFormatsTR
    {
        [TestInitialize]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("tr");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestEveryMinute()
        {
            Assert.AreEqual("Her dakika", ExpressionDescriptor.GetDescription("* * * * *"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Her dakika", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Her dakika", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestEveryHour()
        {
            Assert.AreEqual("Her saat", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Her saat", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("Saat 11:00 PM, Pazartesi ile Cuma arasında", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestEverySecond()
        {
            Assert.AreEqual("Her saniye", ExpressionDescriptor.GetDescription("* * * * * *"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Her 45 saniyede bir", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Her 05 dakikada bir", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("Her 10 dakikada bir", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Her 05 dakikada bir", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("Saat 11:30 AM, Pazartesi ile Cuma arasında", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestDailyAtTime()
        {
            Assert.AreEqual("Saat 11:30 AM", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestMinuteSpan()
        {
            Assert.AreEqual("Saat 11:00 AM ve 11:10 AM arasındaki her dakika", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("Her dakika, sadece Mart için", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("Her dakika, sadece Mart ve Haziran için", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }
        [TestMethod]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("Saat 02:30 PM ve 04:30 PM", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("Saat 06:30 AM, 02:30 PM ve 04:30 PM", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestOnceAWeek()
        {
            Assert.AreEqual("Saat 09:46 AM, sadece Pazartesi günü", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestDayOfMonth()
        {
            Assert.AreEqual("Saat 12:23 PM, ayın 15. günü", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestMonthName()
        {
            Assert.AreEqual("Saat 12:23 PM, sadece Ocak için", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("Saat 12:23 PM, sadece Ocak için", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestMonthNameRange2()
        {
            Assert.AreEqual("Saat 12:23 PM, Ocak ile Şubat arasında", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestMonthNameRange3()
        {
            Assert.AreEqual("Saat 12:23 PM, Ocak ile Mart arasında", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("Saat 12:23 PM, sadece Pazar günü", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("Her 05 dakikada bir, saat 03:00 PM, Pazartesi ile Cuma arasında", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("Her dakika, ayın üçüncü Pazartesi günü", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("Her dakika, ayın son Perşembe günü", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual("Her 05 dakikada bir, ayın son günü, sadece Ocak için", ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("Her dakika, ayın son iş günü", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Her dakika, ayın son iş günü", ExpressionDescriptor.GetDescription("* * WL * *"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual("Her dakika, ayın ilk iş günü", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Her dakika, ayın ilk iş günü", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("Her dakika, ayın 5. günü sonrasındaki ilk iş günü", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Her dakika, ayın 5. günü sonrasındaki ilk iş günü", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("Saat 02:02:30 PM", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestSecondInternvals()
        {
            Assert.AreEqual("Dakikaların 05. ve 10. saniyeleri arası", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("Dakikaların 05. ve 10. saniyeleri arası, saatlerin 30. ve 35. dakikaları arası, 10:00 AM ile 01:00 PM arasında", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("Dakikaların 30. saniyesinde, her 05 dakikada bir", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("Saatlerin 30. dakikasında, 10:00 AM ile 02:00 PM arasında, sadece Çarşamba ve Cuma günü", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("Dakikaların 10. saniyesinde, her 05 dakikada bir", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual("Her 03 dakikada bir, saatlerin 02. ve 59. dakikaları arası, saat 01:00 AM, 09:00 AM, ve 10:00 PM, ayın 11. ve 26. günleri arası, Ocak ile Haziran arasında", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("Saat 06:00 AM", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("Saatlerin 05. dakikasında", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }
        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Her saniye, sadece 2013 için", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Her dakika, sadece 2013 için", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual("Her dakika, sadece 2013 ve 2014 için", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestYearRange2()
        {
            Assert.AreEqual("Saat 12:23 PM, Ocak ile Şubat arasında, 2013 ile 2014 arasında", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestYearRange3()
        {
            Assert.AreEqual("Saat 12:23 PM, Ocak ile Mart arasında, 2013 ile 2015 arasında", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestHourRange()
        {
            Assert.AreEqual("Her 30 dakikada bir, 08:00 AM ile 10:00 AM arasında, ayın 5 ve 20. günü", ExpressionDescriptor.GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestDayOfWeekModifier()
        {
            Assert.AreEqual("Saat 12:23 PM, ayın ikinci Pazar günü", ExpressionDescriptor.GetDescription("23 12 * * SUN#2"));
        }

        [TestMethod]
        [DeploymentItem(@"tr\CronExpressionDescriptor.resources.dll", "tr")]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.AreEqual("Saat 12:23 PM, ayın ikinci Pazar günü", ExpressionDescriptor.GetDescription("23 12 * * 1#2", options));
        }

    }
}