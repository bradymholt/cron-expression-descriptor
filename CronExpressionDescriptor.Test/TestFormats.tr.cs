using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Threading;
using System.Globalization;
using System.IO;

namespace CronExpressionDescriptor.Test
{
    [TestFixture]
    public class TestFormatsTR
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [Test]
        
        public void TestEveryMinute()
        {
            Assert.AreEqual("Her dakika", ExpressionDescriptor.GetDescription("* * * * *"));
        }
        [Test]
        
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Her dakika", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Her dakika", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }
        [Test]
        
        public void TestEveryHour()
        {
            Assert.AreEqual("Her saat", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Her saat", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }
        [Test]
        
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("Saat 23:00, Pazartesi ile Cuma arasında", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }
        [Test]
        
        public void TestEverySecond()
        {
            Assert.AreEqual("Her saniye", ExpressionDescriptor.GetDescription("* * * * * *"));
        }
        [Test]
        
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Her 45 saniyede bir", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }
        [Test]
        
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Her 5 dakikada bir", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("Her 10 dakikada bir", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }
        [Test]
        
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Her 5 dakikada bir", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [Test]
        
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("Saat 11:30, Pazartesi ile Cuma arasında", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [Test]
        
        public void TestDailyAtTime()
        {
            Assert.AreEqual("Saat 11:30", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }
        [Test]
        
        public void TestMinuteSpan()
        {
            Assert.AreEqual("Saat 11:00 ve 11:10 arasındaki her dakika", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [Test]
        
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("Her dakika, sadece Mart için", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [Test]
        
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("Her dakika, sadece Mart ve Haziran için", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }
        [Test]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("Saat 14:30 ve 16:30", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [Test]
        
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("Saat 06:30, 14:30 ve 16:30", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [Test]
        
        public void TestOnceAWeek()
        {
            Assert.AreEqual("Saat 09:46, sadece Pazartesi günü", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }
        [Test]
        
        public void TestDayOfMonth()
        {
            Assert.AreEqual("Saat 12:23, ayın 15. günü", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [Test]
        
        public void TestMonthName()
        {
            Assert.AreEqual("Saat 12:23, sadece Ocak için", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
        }

        [Test]
        
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("Saat 12:23, sadece Ocak için", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
        }
        [Test]
        
        public void TestMonthNameRange2()
        {
            Assert.AreEqual("Saat 12:23, Ocak ile Şubat arasında", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
        }

        [Test]
        
        public void TestMonthNameRange3()
        {
            Assert.AreEqual("Saat 12:23, Ocak ile Mart arasında", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
        }

        [Test]
        
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("Saat 12:23, sadece Pazar günü", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }
        [Test]
        
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("Her 5 dakikada bir, saat 15:00, Pazartesi ile Cuma arasında", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [Test]
        
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("Her dakika, ayın üçüncü Pazartesi günü", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [Test]
        
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("Her dakika, ayın son Perşembe günü", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }
        [Test]
        
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual("Her 5 dakikada bir, ayın son günü, sadece Ocak için", ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [Test]
        
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("Her dakika, ayın son iş günü", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [Test]
        
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Her dakika, ayın son iş günü", ExpressionDescriptor.GetDescription("* * WL * *"));
        }
        [Test]
        
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual("Her dakika, ayın ilk iş günü", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [Test]
        
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Her dakika, ayın ilk iş günü", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [Test]
        
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("Her dakika, ayın 5. günü sonrasındaki ilk iş günü", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }
        [Test]
        
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Her dakika, ayın 5. günü sonrasındaki ilk iş günü", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [Test]
        
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("Saat 14:02:30", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [Test]
        
        public void TestSecondInternvals()
        {
            Assert.AreEqual("Dakikaların 5. ve 10. saniyeleri arası", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }
        [Test]
        
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("Dakikaların 5. ve 10. saniyeleri arası, saatlerin 30. ve 35. dakikaları arası, 10:00 ile 12:59 arasında", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Test]
        
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("Dakikaların 30. saniyesinde, her 5 dakikada bir", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [Test]
        
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("Saatlerin 30. dakikasında, 10:00 ile 13:59 arasında, sadece Çarşamba ve Cuma günü", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }
        [Test]
        
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("Dakikaların 10. saniyesinde, her 5 dakikada bir", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }
        [Test]
        
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual("Her 3 dakikada bir, saatlerin 2. ve 59. dakikaları arası, saat 01:00, 09:00, ve 22:00, ayın 11. ve 26. günleri arası, Ocak ile Haziran arasında", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }
        [Test]
        
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("Saat 06:00", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }
        [Test]
        
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("Saatlerin 5. dakikasında", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }
        [Test]
        
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Her saniye, sadece 2013 için", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }

        [Test]
        
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Her dakika, sadece 2013 için", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [Test]
        
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual("Her dakika, sadece 2013 ve 2014 için", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [Test]
        
        public void TestYearRange2()
        {
            Assert.AreEqual("Saat 12:23, Ocak ile Şubat arasında, 2013 ile 2014 arasında", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Test]
        
        public void TestYearRange3()
        {
            Assert.AreEqual("Saat 12:23, Ocak ile Mart arasında, 2013 ile 2015 arasında", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Test]
        
        public void TestHourRange()
        {
            Assert.AreEqual("Her 30 dakikada bir, 08:00 ile 09:59 arasında, ayın 5 ve 20. günü", ExpressionDescriptor.GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [Test]
        
        public void TestDayOfWeekModifier()
        {
            Assert.AreEqual("Saat 12:23, ayın ikinci Pazar günü", ExpressionDescriptor.GetDescription("23 12 * * SUN#2"));
        }

        [Test]
        
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.AreEqual("Saat 12:23, ayın ikinci Pazar günü", ExpressionDescriptor.GetDescription("23 12 * * 1#2", options));
        }

        [Test]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradyholt/cron-expression-descriptor/issues/49
            Assert.AreEqual("Her 30 saniyede bir, başlangıç dakikaların 5. saniyesinde", ExpressionDescriptor.GetDescription("5/30 * * * * ?"));
        }

        [Test]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.AreEqual("Her 30 dakikada bir, başlangıç saatlerin 5. dakikasında", ExpressionDescriptor.GetDescription("0 5/30 * * * ?"));
        }
        
        [Test]
        public void TestHoursInternalWithStepValue()
        {
            Assert.AreEqual("Her saniye, her 8 saatte, başlangıç saat 05:00", ExpressionDescriptor.GetDescription("* * 5/8 * * ?"));
        }
        
        [Test]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.AreEqual("Saat 07:05, 3 günde bir, başlangıç ayın 2. günü", ExpressionDescriptor.GetDescription("0 5 7 2/3 * ? *"));
        }
        
        [Test]
        public void TestMonthInternalWithStepValue()
        {
            Assert.AreEqual("Saat 07:05, 2 ayda bir, Mart ile Aralık arasında", ExpressionDescriptor.GetDescription("0 5 7 ? 3/2 ? *"));
        }
        
        [Test]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.AreEqual("Saat 07:05, ayın her 3 günü, Salı ile Cumartesi arasında", ExpressionDescriptor.GetDescription("0 5 7 ? * 2/3 *"));
        }
                
        [Test]
        public void TestYearInternalWithStepValue()
        {
            Assert.AreEqual("Saat 07:05, 4 yılda bir, 2016 ile 9999 arasında", ExpressionDescriptor.GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}