using NUnit.Framework;
using System;
using System.Globalization;
using System.Threading;

namespace CronExpressionDescriptor.Test
{
    /// <summary>
    /// Tests for Ukrainian translations
    /// </summary>
    [TestFixture]
    public class TestFormatsUk
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("uk-UA");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }
     
        [Test]
        public void TestEveryMinute()
        {
           Assert.AreEqual("Щохвилини", ExpressionDescriptor.GetDescription("* * * * *"));
        }

        [Test]
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Щохвилини", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Щохвилини", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }

        [Test]
        public void TestEveryHour()
        {
            Assert.AreEqual("Щогодини", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Щогодини", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }

        [Test]
#if __MonoCS__
        [Ignore("Mono is returning wrong apostrophe character for UK culture..")]
#endif
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("О 23:00, понеділок по п'ятниця", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }

        [Test]
        public void TestEverySecond()
        {
            Assert.AreEqual("Щосекунди", ExpressionDescriptor.GetDescription("* * * * * *"));
        }

        [Test]
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Кожні 45 секунд", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }

        [Test]
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Кожні 5 хвилин", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("Кожні 10 хвилин", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }

        [Test]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Кожні 5 хвилин", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [Test]
#if __MonoCS__
        [Ignore("Mono is returning wrong apostrophe character for UK culture..")]
#endif
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("О 11:30, понеділок по п'ятниця", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [Test]
        public void TestDailyAtTime()
        {
            Assert.AreEqual("О 11:30", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }

        [Test]
        public void TestMinuteSpan()
        {
            Assert.AreEqual("Щохвилини між 11:00 та 11:10", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [Test]
        public void TestOneMonthOnly()
        {
            Assert.IsTrue(string.Equals("Щохвилини, тільки в березень", ExpressionDescriptor.GetDescription("* * * 3 *"),
                Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestTwoMonthsOnly()
        {
            Assert.IsTrue(string.Equals("Щохвилини, тільки в березень та червень", ExpressionDescriptor.GetDescription("* * * 3,6 *"),
               Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("О 14:30 та 16:30", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [Test]
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("О 06:30, 14:30 та 16:30", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [Test]
        public void TestOnceAWeek()
        {
            Assert.AreEqual("О 09:46, тільки в понеділок", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }

        [Test]
        public void TestDayOfMonth()
        {
            Assert.AreEqual("О 12:23, на 15 день місяця", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [Test]
        public void TestMonthName()
        {
            Assert.IsTrue(string.Equals("О 12:23, тільки в січень", ExpressionDescriptor.GetDescription("23 12 * JAN * "),
             Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.IsTrue(string.Equals("О 12:23, тільки в січень", ExpressionDescriptor.GetDescription("23 12 ? JAN *"),
               Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestMonthNameRange2()
        {
            Assert.IsTrue(string.Equals("О 12:23, січень по лютий", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"),
             Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestMonthNameRange3()
        {
            Assert.IsTrue(string.Equals("О 12:23, січень по березень", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"),
             Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("О 12:23, тільки в неділя", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }

        [Test]
#if __MonoCS__
        [Ignore("Mono is returning wrong apostrophe character for UK culture..")]
#endif
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("Кожні 5 хвилин, о 15:00, понеділок по п'ятниця", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [Test]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("Щохвилини, в третій понеділок місяця", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [Test]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("Щохвилини, в останній четвер місяця", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }

        [Test]
        public void TestLastDayOfTheMonth()
        {
            Assert.IsTrue(string.Equals("Кожні 5 хвилин, в останній день місяця, тільки в січень", ExpressionDescriptor.GetDescription("*/5 * L JAN *"),
              Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("Щохвилини, в останній будень місяця", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [Test]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Щохвилини, в останній будень місяця", ExpressionDescriptor.GetDescription("* * WL * *"));
        }

        [Test]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual("Щохвилини, в перший будень місяця", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [Test]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Щохвилини, в перший будень місяця", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [Test]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("Щохвилини, в будень найближчий до 5 дня місяця", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }

        [Test]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Щохвилини, в будень найближчий до 5 дня місяця", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [Test]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("О 14:02:30", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [Test]
        public void TestSecondInternvals()
        {
            Assert.AreEqual("З 5 по 10 секунду", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }

        [Test]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("З 5 по 10 секунду, з 30 по 35 хвилину, між 10:00 та 12:59", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Test]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("О 30 секунді, кожні 5 хвилин", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [Test]
#if __MonoCS__
        [Ignore("Mono is returning wrong apostrophe character for UK culture..")]
#endif
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("О 30 хвилині, між 10:00 та 13:59, тільки в середа та п'ятниця", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Test]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("О 10 секунді, кожні 5 хвилин", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }

        [Test]
        public void TestBetweenWithInterval()
        {
            Assert.IsTrue(string.Equals("Кожні 3 хвилин, з 2 по 59 хвилину, о 01:00, 09:00, та 22:00, між 11 та 26 днями місяця, січень по червень", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"),
              Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("О 06:00", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }

        [Test]
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("О 5 хвилині", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }

        [Test]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Щосекунди, тільки в 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }
        
        [Test]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Щохвилини, тільки в 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [Test]
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual("Щохвилини, тільки в 2013 та 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [Test]
        public void TestYearRange2()
        {
            Assert.IsTrue(string.Equals("О 12:23, січень по лютий, 2013 по 2014", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"),
                Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestYearRange3()
        {
            Assert.IsTrue(string.Equals("О 12:23, січень по березень, 2013 по 2015", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"),
               Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestHourRange()
        {
            Assert.AreEqual("Кожні 30 хвилин, між 08:00 та 09:59, на 5 та 20 день місяця", ExpressionDescriptor.GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [Test]
        public void TestDayOfWeekModifier()
        {
            Assert.AreEqual("О 12:23, в другий неділя місяця", ExpressionDescriptor.GetDescription("23 12 * * SUN#2"));
        }

        [Test]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.AreEqual("О 12:23, в другий неділя місяця", ExpressionDescriptor.GetDescription("23 12 * * 1#2", options));
        }

        [Test]
        public void TestHourRangeWithEveryPortion()
        {
            Assert.AreEqual("О 25 хвилині, кожні 13 годин, між 07:00 та 19:59", ExpressionDescriptor.GetDescription("0 25 7-19/13 ? * *"));
        }

        [Test]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.AreEqual("О 25 хвилині, кожні 13 годин, між 07:00 та 20:59", ExpressionDescriptor.GetDescription("0 25 7-20/13 ? * *"));
        }

        [Test]
        public void TestEvery3Day()
        {
            Assert.AreEqual("О 08:00, кожен 3 день", ExpressionDescriptor.GetDescription("0 0 8 1/3 * ? *"));
        }

        [Test]
        public void TestsEvery3DayOfTheWeek()
        {
            Assert.AreEqual("О 10:15, кожен 3 день тижня", ExpressionDescriptor.GetDescription("0 15 10 ? * */3"));
        }

        [Test]
        public void TestEvery3Month()
        {
            Assert.AreEqual("О 07:05, на 2 день місяця, кожен 3 місяць", ExpressionDescriptor.GetDescription("0 5 7 2 1/3 ? *"));
        }

        [Test]
        public void TestEvery2Years()
        {
            Assert.IsTrue(string.Equals("О 06:15, на 1 день місяця, тільки в січень, кожні 2 роки", ExpressionDescriptor.GetDescription("0 15 6 1 1 ? 1/2"),
                Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }
        
        [Test]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradyholt/cron-expression-descriptor/issues/49
            Assert.AreEqual("Кожні 30 секунд, початок о 5 секунді", ExpressionDescriptor.GetDescription("5/30 * * * * ?"));
        }

        [Test]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.AreEqual("Кожні 30 хвилин, початок о 5 хвилині", ExpressionDescriptor.GetDescription("0 5/30 * * * ?"));
        }
        
        [Test]
        public void TestHoursInternalWithStepValue()
        {
            Assert.AreEqual("Щосекунди, кожні 8 годин, початок о 05:00", ExpressionDescriptor.GetDescription("* * 5/8 * * ?"));
        }
        
        [Test]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.AreEqual("О 07:05, кожен 3 день, початок на 2 день місяця", ExpressionDescriptor.GetDescription("0 5 7 2/3 * ? *"));
        }
        
        [Test]
        public void TestMonthInternalWithStepValue()
        {
            Assert.IsTrue(string.Equals("О 07:05, кожен 2 місяць, березень по грудень", ExpressionDescriptor.GetDescription("0 5 7 ? 3/2 ? *"),
                Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }
        
        [Test]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.AreEqual("О 07:05, кожен 3 день тижня, вівторок по субота", ExpressionDescriptor.GetDescription("0 5 7 ? * 2/3 *"));
        }
                
        [Test]
        public void TestYearInternalWithStepValue()
        {
            Assert.AreEqual("О 07:05, кожні 4 роки, 2016 по 9999", ExpressionDescriptor.GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}