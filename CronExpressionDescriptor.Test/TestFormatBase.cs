using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test
{
    [TestClass]
    public abstract class TestFormatBase : ITimeFormatter
    {
        private static readonly Regex ExpressionValidationRegex = new Regex(@"(\d+)[^|]", RegexOptions.Compiled); 
        private static readonly Regex TimeArgumentsRegex = new Regex(@"\|T(\d+)\|", RegexOptions.Compiled);
        private static readonly Regex SecondsArgumentsRegex = new Regex(@"\|S(\d+)\|", RegexOptions.Compiled);
        private static readonly Regex MinutesArgumentsRegex = new Regex(@"\|M(\d+)\|", RegexOptions.Compiled);
        private static readonly Regex HoursArgumentsRegex = new Regex(@"\|H(\d+)\|", RegexOptions.Compiled);
        private static readonly Regex DaysArgumentsRegex = new Regex(@"\|D(\d+)\|", RegexOptions.Compiled); 
        private static readonly Regex YearsArgumentsRegex = new Regex(@"\|Y(\d+)\|", RegexOptions.Compiled); 
        
        
        private String CultureName { get; set; }
        private FormatsTypeEnum FormatsType { get; set; }
        protected Options Options { get; private set; }

        protected TestFormatBase(string cultureName, FormatsTypeEnum formatsType)
        {
            CultureName = cultureName;
            FormatsType = formatsType;
        }
        
        [TestInitialize]
        public void SetUp()
        {
            var myCultureInfo = new CultureInfo(CultureName, false);

            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;

            Options = new Options { FormatsType = FormatsType };
        }

        #region Date handling methods

        public virtual string GetTimeString(int hour, int minute)
        {
            return GetTimeStringLegacy(hour, minute);
        }

        public virtual string GetTimeString(int hour, int minute, int second)
        {
            return GetTimeStringLegacy(hour, minute, second);
        }

        #region Legacy

        protected string GetTimeStringLegacy(int hour, int minute)
        {
            return string.Format("{0} {1}", GetHourTimeLegacy(hour, minute), GetAmPm(hour));
        }

        protected string GetTimeStringLegacy(int hour, int minute, int second)
        {
            return string.Format("{0}:{2:00} {1}", GetHourTimeLegacy(hour, minute), GetAmPm(hour), second);
        }

        protected string GetHourTimeLegacy(int hour, int minute)
        {
            return string.Format("{0:00}:{1:00}", hour > 12 ? hour - 12 : hour, minute);
        }

        #endregion

        #region AmPm Without Leading Zero

        protected string GetTimeStringAmPmWithoutLeadingZero(int hour, int minute, int second)
        {
            return string.Format("{0}:{2:00} {1}", GetHourTimeAmPmWithoutLeadingZero(hour, minute), GetAmPm(hour),
                second);
        }

        protected string GetTimeStringAmPmWithoutLeadingZero(int hour, int minute)
        {
            return string.Format("{0} {1}", GetHourTimeAmPmWithoutLeadingZero(hour, minute), GetAmPm(hour));
        }

        protected string GetHourTimeAmPmWithoutLeadingZero(int hour, int minute)
        {
            return string.Format("{0}:{1:00}", hour > 12 ? hour - 12 : hour, minute);
        }

        protected string GetAmPm(int hour)
        {
            return hour > 11 ? "PM" : "AM";
        }

        #endregion

        #region 24 Hours

        protected string GetTimeString24Hours(int hour, int minute)
        {
            return string.Format("{0:00}:{1:00}", hour, minute);
        }

        protected string GetTimeString24Hours(int hour, int minute, int second)
        {
            return string.Format("{0}:{1:00}", GetTimeString24Hours(hour, minute), second);
        }

        #endregion

        #region 24 Hours Without Leading Zero

        protected string GetTimeString24HoursWithoutLeadingZero(int hour, int minute)
        {
            return string.Format("{0}:{1:00}", hour, minute);
        }

        protected string GetTimeString24HoursWithoutLeadingZero(int hour, int minute, int second)
        {
            return string.Format("{0}:{1:00}", GetTimeString24HoursWithoutLeadingZero(hour, minute), second);
        }

        #endregion

        #endregion

        #region Numbers handling methods

        private string GetSecondString(int minute)
        {
            return GetToStringWithLeadingZeroIfLegacy(minute);
        }

        private string GetMinuteString(int minute)
        {
            return GetToStringWithLeadingZeroIfLegacy(minute);
        }

        private string GetHourString(int minute)
        {
            return GetToStringWithLeadingZeroIfLegacy(minute);
        }

        private string GetToString(int number)
        {
            return string.Format("{0}", number);
        }

        private string GetToStringWithLeadingZeroIfLegacy(int number)
        {
            switch (Options.FormatsType)
            {
                case FormatsTypeEnum.Legacy:
                    return string.Format("{0:00}", number);
                case FormatsTypeEnum.CultureProvided:
                    return GetToString(number);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion

        #region Test helper methods

        private void RunTest(Func<string> getExpectedValue, string cronExpression, Options options = null
            , IEnumerable<Time> times = null
            , IEnumerable<int> seconds = null
            , IEnumerable<int> minutes = null
            , IEnumerable<int> hours = null
            , IEnumerable<int> days = null
            , IEnumerable<int> years = null)
        {
            RunTest(getExpectedValue(), cronExpression, options, times, seconds, minutes, hours, days, years);
        }

        private void RunTest(string expectedValue, string cronExpression, Options options = null
            , IEnumerable<Time> times = null
            , IEnumerable<int> seconds = null
            , IEnumerable<int> minutes = null
            , IEnumerable<int> hours = null
            , IEnumerable<int> days = null
            , IEnumerable<int> years = null)
        {
            if (expectedValue == null)
            {
                Assert.Inconclusive(cronExpression);
            }
            else
            {
                string computedValue = ExpressionDescriptor.GetDescription(cronExpression, options ?? Options);

                if (ExpressionValidationRegex.IsMatch(expectedValue))
                {
                    Assert.Fail(@"Expected value ""{0}"" for ""{1}"" contains number not handled by a replacement tag", expectedValue, cronExpression);
                }
                try
                {
                    expectedValue = GetExpectedWithTimeReplaced(expectedValue, times ?? Enumerable.Empty<Time>());
                    expectedValue = GetExpectedWithSecondsReplaced(expectedValue, seconds ?? Enumerable.Empty<int>());
                    expectedValue = GetExpectedWithMinutesReplaced(expectedValue, minutes ?? Enumerable.Empty<int>());
                    expectedValue = GetExpectedWithHoursReplaced(expectedValue, hours ?? Enumerable.Empty<int>());
                    expectedValue = GetExpectedWithDaysReplaced(expectedValue, days ?? Enumerable.Empty<int>());
                    expectedValue = GetExpectedWithYearsReplaced(expectedValue, years ?? Enumerable.Empty<int>());
                }
                catch (Exception e)
                {
                    Assert.Fail(@"Expected value ""{0}"" for ""{1}"" contains invalid replacement tags for the pattern : {2}", expectedValue, cronExpression, e);
                }
                Assert.AreEqual(expectedValue, computedValue);
            }
        }

        private string GetExpectedWithTimeReplaced(string expectedValue, IEnumerable<Time> times)
        {
            return string.Format(TimeArgumentsRegex.Replace(expectedValue, "{$1}"), times.Select(t => (object)t.Format(this)).ToArray());
        }

        private string GetExpectedWithSecondsReplaced(string expectedValue, IEnumerable<int> seconds)
        {
            return string.Format(SecondsArgumentsRegex.Replace(expectedValue, "{$1}"), seconds.Select(s => (object)GetSecondString(s)).ToArray());
        }

        private string GetExpectedWithMinutesReplaced(string expectedValue, IEnumerable<int> minutes)
        {
            return string.Format(MinutesArgumentsRegex.Replace(expectedValue, "{$1}"), minutes.Select(m => (object)GetMinuteString(m)).ToArray());
        }

        private string GetExpectedWithHoursReplaced(string expectedValue, IEnumerable<int> hours)
        {
            return string.Format(HoursArgumentsRegex.Replace(expectedValue, "{$1}"), hours.Select(h => (object)GetHourString(h)).ToArray());
        }

        private string GetExpectedWithDaysReplaced(string expectedValue, IEnumerable<int> days)
        {
            return string.Format(DaysArgumentsRegex.Replace(expectedValue, "{$1}"), days.Select(d => (object)GetToString(d)).ToArray());
        }

        private string GetExpectedWithYearsReplaced(string expectedValue, IEnumerable<int> years)
        {
            return string.Format(YearsArgumentsRegex.Replace(expectedValue, "{$1}"), years.Select(y => (object)GetToString(y)).ToArray());
        }

        #endregion

        #region Actual tests

        [TestMethod]
        public void TestEveryMinute()
        {
            RunTest(GetExpectedEveryMinute, "* * * * *");
        }

        protected abstract string GetExpectedEveryMinute();

        [TestMethod]
        public void TestEvery1Minute()
        {
            RunTest(GetExpectedEvery1Minute, "*/1 * * * *");
            RunTest(GetExpectedEvery1Minute, "0 0/1 * * * ?");
        }

        protected abstract string GetExpectedEvery1Minute();

        [TestMethod]
        public void TestEveryHour()
        {
            RunTest(GetExpectedEveryHour, "0 0 * * * ?");
            RunTest(GetExpectedEveryHour, "0 0 0/1 * * ?");
        }

        protected abstract string GetExpectedEveryHour();

        [TestMethod]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            RunTest(GetExpectedTimeOfDayCertainDaysOfWeek, "0 23 ? * MON-FRI", times: new[] { new Time(23, 0) });
        }

        protected abstract string GetExpectedTimeOfDayCertainDaysOfWeek();

        [TestMethod]
        public void TestEverySecond()
        {
            RunTest(GetExpectedEverySecond, "* * * * * *");
        }

        protected abstract string GetExpectedEverySecond();

        [TestMethod]
        public void TestEvery45Seconds()
        {
            RunTest(GetExpectedEvery45Seconds, "*/45 * * * * *"
                , seconds: new[] { 45 });
        }

        protected abstract string GetExpectedEvery45Seconds();

        [TestMethod]
        public void TestEvery5Seconds()
        {
            RunTest(GetExpectedEvery5Seconds, "*/5 * * * * *"
                , seconds: new[] { 5 });
        }

        protected abstract string GetExpectedEvery5Seconds();

        [TestMethod]
        public void TestEvery5Minutes()
        {
            RunTest(GetExpectedEvery5Minutes, "*/5 * * * *", minutes: new[] { 5 });
        }

        protected abstract string GetExpectedEvery5Minutes();

        [TestMethod]
        public void TestEvery10Minutes()
        {
            RunTest(GetExpectedEvery10Minutes, "0 0/10 * * * ?"
                , minutes: new[] { 10 });
        }

        protected abstract string GetExpectedEvery10Minutes();

        [TestMethod]
        public void TestEvery5MinutesOnTheSecond()
        {
            RunTest(GetExpectedEvery5MinutesOnTheSecond, "0 */5 * * * *", minutes: new[] { 5 });
        }

        protected abstract string GetExpectedEvery5MinutesOnTheSecond();

        [TestMethod]
        public void TestWeekdaysAtTime()
        {
            RunTest(GetExpectedWeekdaysAtTime, "30 11 * * 1-5", times: new[] { new Time(11, 30) });
        }

        protected abstract string GetExpectedWeekdaysAtTime();

        [TestMethod]
        public void TestDailyAtTime()
        {
            RunTest(GetExpectedDailyAtTime, "30 11 * * *", times: new[] { new Time(11, 30) });
        }

        protected abstract string GetExpectedDailyAtTime();

        [TestMethod]
        public void TestMinuteSpan()
        {
            RunTest(GetExpectedMinuteSpan, "0-10 11 * * *", times: new[] { new Time(11, 0), new Time(11, 10) });
        }

        protected abstract string GetExpectedMinuteSpan();

        [TestMethod]
        public void TestOneMonthOnly()
        {
            RunTest(GetExpectedOneMonthOnly, "* * * 3 *");
        }

        protected abstract string GetExpectedOneMonthOnly();

        [TestMethod]
        public void TestTwoMonthsOnly()
        {
            RunTest(GetExpectedTwoMonthsOnly, "* * * 3,6 *");
        }

        protected abstract string GetExpectedTwoMonthsOnly();

        [TestMethod]
        public void TestTwoTimesEachAfternoon()
        {
            RunTest(GetExpectedTwoTimesEachAfternoon, "30 14,16 * * *", times: new[] { new Time(14, 30), new Time(16, 30) });
        }

        protected abstract string GetExpectedTwoTimesEachAfternoon();

        [TestMethod]
        public void TestThreeTimesDaily()
        {
            RunTest(GetExpectedThreeTimesDaily, "30 6,14,16 * * *", times: new[] { new Time(6, 30), new Time(14, 30), new Time(16, 30) });
        }

        protected abstract string GetExpectedThreeTimesDaily();

        [TestMethod]
        public void TestOnceAWeek()
        {
            RunTest(GetExpectedOnceAWeek, "46 9 * * 1", times: new[] { new Time(9, 46)});
        }

        protected abstract string GetExpectedOnceAWeek();

        [TestMethod]
        public void TestDayOfMonth()
        {
            RunTest(GetExpectedDayOfMonth, "23 12 15 * *"
                , times: new[] { new Time(12, 23) }
                , days: new[] { 15 });
        }

        protected abstract string GetExpectedDayOfMonth();

        [TestMethod]
        public void TestMonthName()
        {
            RunTest(GetExpectedMonthName, "23 12 * JAN *", times: new[] { new Time(12, 23) });
        }

        protected abstract string GetExpectedMonthName();

        [TestMethod]
        public void TestDayOfMonthWithQuestionMark()
        {
            RunTest(GetExpectedDayOfMonthWithQuestionMark, "23 12 ? JAN *", times: new[] { new Time(12, 23) });
        }

        protected abstract string GetExpectedDayOfMonthWithQuestionMark();

        [TestMethod]
        public void TestMonthNameRange2()
        {
            RunTest(GetExpectedMonthNameRange2, "23 12 * JAN-FEB *", times: new[] { new Time(12, 23) });
        }

        protected abstract string GetExpectedMonthNameRange2();

        [TestMethod]
        public void TestMonthNameRange3()
        {
            RunTest(GetExpectedMonthNameRange3, "23 12 * JAN-MAR *", times: new[] { new Time(12, 23) });
        }

        protected abstract string GetExpectedMonthNameRange3();

        [TestMethod]
        public void TestDayOfWeekName()
        {
            RunTest(GetExpectedDayOfWeekName, "23 12 * * SUN", times: new[] { new Time(12, 23) });
        }

        protected abstract string GetExpectedDayOfWeekName();

        [TestMethod]
        public void TestDayOfWeekRange()
        {
            RunTest(GetExpectedDayOfWeekRange, "*/5 15 * * MON-FRI"
                , times: new[] { new Time(15, 0) }
                , minutes: new[] { 5 });
        }

        protected abstract string GetExpectedDayOfWeekRange();

        [TestMethod]
        public void TestDayOfWeekOnceInMonth()
        {
            RunTest(GetExpectedDayOfWeekOnceInMonth, "* * * * MON#3");
        }

        protected abstract string GetExpectedDayOfWeekOnceInMonth();

        [TestMethod]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            RunTest(GetExpectedLastDayOfTheWeekOfTheMonth, "* * * * 4L");
        }

        protected abstract string GetExpectedLastDayOfTheWeekOfTheMonth();

        [TestMethod]
        public void TestLastDayOfTheMonth()
        {
            RunTest(GetExpectedLastDayOfTheMonth, "*/5 * L JAN *", minutes: new[] { 5 });
        }

        protected abstract string GetExpectedLastDayOfTheMonth();

        [TestMethod]
        public void TestLastWeekdayOfTheMonth()
        {
            RunTest(GetExpectedLastWeekdayOfTheMonth, "* * LW * *");
        }

        protected abstract string GetExpectedLastWeekdayOfTheMonth();

        [TestMethod]
        public void TestLastWeekdayOfTheMonth2()
        {
            RunTest(GetExpectedLastWeekdayOfTheMonth2, "* * WL * *");
        }

        protected abstract string GetExpectedLastWeekdayOfTheMonth2();

        [TestMethod]
        public void TestFirstWeekdayOfTheMonth()
        {
            RunTest(GetExpectedFirstWeekdayOfTheMonth, "* * 1W * *");
        }

        protected abstract string GetExpectedFirstWeekdayOfTheMonth();

        [TestMethod]
        public void TestFirstWeekdayOfTheMonth2()
        {
            RunTest(GetExpectedFirstWeekdayOfTheMonth2, "* * W1 * *");
        }

        protected abstract string GetExpectedFirstWeekdayOfTheMonth2();

        [TestMethod]
        public void TestParticularWeekdayOfTheMonth()
        {
            RunTest(GetExpectedParticularWeekdayOfTheMonth, "* * 5W * *"
                , days: new[] { 5 });
        }

        protected abstract string GetExpectedParticularWeekdayOfTheMonth();

        [TestMethod]
        public void TestParticularWeekdayOfTheMonth2()
        {
            RunTest(GetExpectedParticularWeekdayOfTheMonth2, "* * W5 * *"
                , days: new[] { 5 });
        }

        protected abstract string GetExpectedParticularWeekdayOfTheMonth2();

        [TestMethod]
        public void TestTimeOfDayWithSeconds()
        {
            RunTest(GetExpectedTimeOfDayWithSeconds, "30 02 14 * * *", times: new[] { new Time(14, 2, 30) });
        }

        protected abstract string GetExpectedTimeOfDayWithSeconds();

        [TestMethod]
        public void TestSecondIntervals()
        {
            RunTest(GetExpectedSecondIntervals, "5-10 * * * * *", seconds: new[] { 5, 10 });
        }

        protected abstract string GetExpectedSecondIntervals();

        [TestMethod]
        public void TestSecondMinutesHoursIntervals()
        {
            RunTest(GetExpectedSecondMinutesHoursIntervals, "5-10 30-35 10-12 * * *"
                , times: new[] { new Time(10, 0), new Time(12, 59) }
                , seconds: new[] { 5, 10 }
                , minutes: new[] { 30, 35 });
        }

        protected abstract string GetExpectedSecondMinutesHoursIntervals();

        [TestMethod]
        public void TestEvery5MinutesAt30Seconds()
        {
            RunTest(GetExpectedEvery5MinutesAt30Seconds, "30 */5 * * * *"
                , seconds: new[] { 30 }
                , minutes: new[] { 5 });
        }

        protected abstract string GetExpectedEvery5MinutesAt30Seconds();

        [TestMethod]
        public void TestMinutesPastTheHourRange()
        {
            RunTest(GetExpectedMinutesPastTheHourRange, "0 30 10-13 ? * WED,FRI"
                , times: new[] { new Time(10, 0), new Time(13, 59) }
                , minutes: new[] { 30 });
        }

        protected abstract string GetExpectedMinutesPastTheHourRange();

        [TestMethod]
        public void TestSecondsPastTheMinuteInterval()
        {
            RunTest(GetExpectedSecondsPastTheMinuteInterval, "10 0/5 * * * ?"
                , seconds: new[] { 10 }
                , minutes: new[] { 5 });
        }

        protected abstract string GetExpectedSecondsPastTheMinuteInterval();

        [TestMethod]
        public void TestBetweenWithInterval()
        {
            RunTest(GetExpectedBetweenWithInterval, "2-59/3 1,9,22 11-26 1-6 ?"
                , times: new[] {new Time(1, 0), new Time(9, 0), new Time(22, 0)}
                , minutes:new[] {3, 2, 59}
                , days:new[] {11, 26});
        }

        protected abstract string GetExpectedBetweenWithInterval();

        [TestMethod]
        public void TestRecurringFirstOfMonth()
        {
            RunTest(GetExpectedRecurringFirstOfMonth, "0 0 6 1/1 * ?", times: new[] { new Time(6, 0) });
        }

        protected abstract string GetExpectedRecurringFirstOfMonth();

        [TestMethod]
        public void TestMinutesPastTheHour()
        {
            RunTest(GetExpectedMinutesPastTheHour, "0 5 0/1 * * ?", minutes: new[] { 5 });
        }

        protected abstract string GetExpectedMinutesPastTheHour();

        [TestMethod]
        public void TestOneYearOnlyWithSeconds()
        {
            RunTest(GetExpectedOneYearOnlyWithSeconds, "* * * * * * 2013"
                , years: new[] { 2013 });
        }

        protected abstract string GetExpectedOneYearOnlyWithSeconds();

        [TestMethod]
        public void TestOneYearOnlyWithoutSeconds()
        {
            RunTest(GetExpectedOneYearOnlyWithoutSeconds, "* * * * * 2013", years: new[] { 2013 });
        }

        protected abstract string GetExpectedOneYearOnlyWithoutSeconds();

        [TestMethod]
        public void TestTwoYearsOnly()
        {
            RunTest(GetExpectedTwoYearsOnly, "* * * * * 2013,2014"
                , years: new[] { 2013, 2014 });
        }

        protected abstract string GetExpectedTwoYearsOnly();

        [TestMethod]
        public void TestYearRange2()
        {
            RunTest(GetExpectedYearRange2, "23 12 * JAN-FEB * 2013-2014"
                , times: new[] { new Time(12, 23) }
                , years: new[] { 2013, 2014 });
        }

        protected abstract string GetExpectedYearRange2();

        [TestMethod]
        public void TestYearRange3()
        {
            RunTest(GetExpectedYearRange3, "23 12 * JAN-MAR * 2013-2015"
                , times: new[] { new Time(12, 23) }
                , years: new[] { 2013, 2015 });
        }

        protected abstract string GetExpectedYearRange3();

        [TestMethod]
        public void TestHourRange()
        {
            RunTest(GetExpectedHourRange, "0 0/30 8-9 5,20 * ?"
                , times: new[] { new Time(8, 0), new Time(9, 59) }
                , minutes: new[] { 30 }
                , days: new[] { 5, 20 });
        }

        protected abstract string GetExpectedHourRange();

        [TestMethod]
        public void TestDayOfWeekModifier()
        {
            RunTest(GetExpectedDayOfWeekModifier, "23 12 * * SUN#2", times: new[] { new Time(12, 23) });
        }

        protected abstract string GetExpectedDayOfWeekModifier();

        [TestMethod]
        public void TestDayOfWeekModifierWithSundayStartOne()
        {
            var options = new Options(Options) {DayOfWeekStartIndexZero = false};
            RunTest(GetExpectedDayOfWeekModifierWithSundayStartOne, "23 12 * * 1#2", options, times: new[] { new Time(12, 23) });
        }

        protected abstract string GetExpectedDayOfWeekModifierWithSundayStartOne();

        [TestMethod]
        public void TestHourRangeWithEveryPortion()
        {
            RunTest(GetExpectedHourRangeWithEveryPortion, "0 25 7-19/13 ? * *"
                , times: new[] { new Time(7, 0), new Time(19, 59) }
                , minutes: new[] { 25 }
                , hours: new[] { 13 });
        }

        protected abstract string GetExpectedHourRangeWithEveryPortion();

        [TestMethod]
        public void TestHourRangeWithTrailingZeroWithEveryPortion()
        {
            RunTest(GetExpectedHourRangeWithTrailingZeroWithEveryPortion, "0 25 7-20/13 ? * *"
                , times: new[] { new Time(7, 0), new Time(20, 59) }
                , minutes: new[] { 25 }
                , hours: new[] { 13 });
        }

        protected abstract string GetExpectedHourRangeWithTrailingZeroWithEveryPortion();


        #endregion
    }
}
