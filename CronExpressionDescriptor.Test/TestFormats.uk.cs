using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.Threading;

namespace CronExpressionDescriptor.Test
{
    /// <summary>
    /// Tests for Ukrainian translations
    /// </summary>
    [TestClass]
    public class TestFormatsUk
    {
        [TestInitialize]
        public void SetUp()
        {
            CultureInfo myCultureInfo = new CultureInfo("uk");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }
     
        [TestMethod]
        public void TestEveryMinute()
        {
           Assert.AreEqual("Щохвилини", ExpressionDescriptor.GetDescription("* * * * *"));
        }

        [TestMethod]
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Щохвилини", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Щохвилини", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }

        [TestMethod]
        public void TestEveryHour()
        {
            Assert.AreEqual("Щогодини", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Щогодини", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }

        [TestMethod]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("О 23:00, понеділок по п'ятниця", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }

        [TestMethod]
        public void TestEverySecond()
        {
            Assert.AreEqual("Щосекунди", ExpressionDescriptor.GetDescription("* * * * * *"));
        }

        [TestMethod]
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Кожні 45 секунд", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }

        [TestMethod]
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Кожні 05 хвилин", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("Кожні 10 хвилин", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }

        [TestMethod]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Кожні 05 хвилин", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [TestMethod]
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("О 11:30, понеділок по п'ятниця", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [TestMethod]
        public void TestDailyAtTime()
        {
            Assert.AreEqual("О 11:30", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }

        [TestMethod]
        public void TestMinuteSpan()
        {
            Assert.AreEqual("Щохвилини між 11:00 та 11:10", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [TestMethod]
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("Щохвилини, тільки в Березень", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [TestMethod]
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("Щохвилини, тільки в Березень та Червень", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }

        [TestMethod]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("О 14:30 та 16:30", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [TestMethod]
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("О 06:30, 14:30 та 16:30", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [TestMethod]
        public void TestOnceAWeek()
        {
            Assert.AreEqual("О 09:46, тільки в понеділок", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }

        [TestMethod]
        public void TestDayOfMonth()
        {
            Assert.AreEqual("О 12:23, на 15 день місяця", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [TestMethod]
        public void TestMonthName()
        {
            Assert.AreEqual("О 12:23, тільки в Січень", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
        }

        [TestMethod]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("О 12:23, тільки в Січень", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
        }

        [TestMethod]
        public void TestMonthNameRange2()
        {
            Assert.AreEqual("О 12:23, Січень по Лютий", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
        }

        [TestMethod]
        public void TestMonthNameRange3()
        {
            Assert.AreEqual("О 12:23, Січень по Березень", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
        }

        [TestMethod]
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("О 12:23, тільки в неділя", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }

        [TestMethod]
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("Кожні 05 хвилин, о 15:00, понеділок по п'ятниця", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [TestMethod]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("Щохвилини, в третій понеділок місяця", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [TestMethod]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("Щохвилини, в останній четвер місяця", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }

        [TestMethod]
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual("Кожні 05 хвилин, в останній день місяця, тільки в Січень", ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [TestMethod]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("Щохвилини, в останній будень місяця", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [TestMethod]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Щохвилини, в останній будень місяця", ExpressionDescriptor.GetDescription("* * WL * *"));
        }

        [TestMethod]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual("Щохвилини, в перший будень місяця", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [TestMethod]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Щохвилини, в перший будень місяця", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [TestMethod]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("Щохвилини, в будень найближчий до 5 дня місяця", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }

        [TestMethod]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Щохвилини, в будень найближчий до 5 дня місяця", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [TestMethod]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("О 14:02:30", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [TestMethod]
        public void TestSecondInternvals()
        {
            Assert.AreEqual("З 05 по 10 секунду", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }

        [TestMethod]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("З 05 по 10 секунду, з 30 по 35 хвилину, між 10:00 та 12:59", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [TestMethod]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("О 30 секунді, кожні 05 хвилин", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [TestMethod]
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("О 30 хвилині, між 10:00 та 13:59, тільки в середа та п'ятниця", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [TestMethod]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("О 10 секунді, кожні 05 хвилин", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }

        [TestMethod]
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual("Кожні 03 хвилин, з 02 по 59 хвилину, о 01:00, 09:00, та 22:00, між 11 та 26 днями місяця, Січень по Червень", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [TestMethod]
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("О 06:00", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }

        [TestMethod]
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("О 05 хвилині", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }

        [TestMethod]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Щосекунди, тільки в 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }
        
        [TestMethod]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Щохвилини, тільки в 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [TestMethod]
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual("Щохвилини, тільки в 2013 та 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [TestMethod]
        public void TestYearRange2()
        {
            Assert.AreEqual("О 12:23, Січень по Лютий, 2013 по 2014", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [TestMethod]
        public void TestYearRange3()
        {
            Assert.AreEqual("О 12:23, Січень по Березень, 2013 по 2015", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [TestMethod]
        public void TestHourRange()
        {
            Assert.AreEqual("Кожні 30 хвилин, між 08:00 та 09:59, на 5 та 20 день місяця", ExpressionDescriptor.GetDescription("0 0/30 8-9 5,20 * ?"));
        }

        [TestMethod]
        public void TestDayOfWeekModifier()
        {
            Assert.AreEqual("О 12:23, в другий неділя місяця", ExpressionDescriptor.GetDescription("23 12 * * SUN#2"));
        }

        [TestMethod]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            Options options = new Options();
            options.DayOfWeekStartIndexZero = false;

            Assert.AreEqual("О 12:23, в другий неділя місяця", ExpressionDescriptor.GetDescription("23 12 * * 1#2", options));
        }

        [TestMethod]
        public void TestHourRangeWithEveryPortion()
        {
            Assert.AreEqual("О 25 хвилині, кожні 13 годин, між 07:00 та 19:59", ExpressionDescriptor.GetDescription("0 25 7-19/13 ? * *"));
        }

        [TestMethod]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            Assert.AreEqual("О 25 хвилині, кожні 13 годин, між 07:00 та 20:59", ExpressionDescriptor.GetDescription("0 25 7-20/13 ? * *"));
        }

        [TestMethod]
        public void TestEvery3Day()
        {
            Assert.AreEqual("О 08:00, кожен 3 день", ExpressionDescriptor.GetDescription("0 0 8 1/3 * ? *"));
        }

        [TestMethod]
        public void TestsEvery3DayOfTheWeek()
        {
            Assert.AreEqual("О 10:15, кожен 3 день тижня", ExpressionDescriptor.GetDescription("0 15 10 ? * */3"));
        }

        [TestMethod]
        public void TestEvery3Month()
        {
            Assert.AreEqual("О 07:05, на 2 день місяця, кожен 3 місяць", ExpressionDescriptor.GetDescription("0 5 7 2 1/3 ? *"));
        }

        [TestMethod]
        public void TestEvery2Years()
        {
            Assert.AreEqual("О 06:15, на 1 день місяця, тільки в Січень, кожні 2 роки", ExpressionDescriptor.GetDescription("0 15 6 1 1 ? 1/2"));
        }
    }
}