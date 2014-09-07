using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.En
{
    [TestClass]
    public abstract class TestFormatsEnBase : TestFormatBase
    {
        public TestFormatsEnBase(FormatsTypeEnum formatsType)
            : base("en", formatsType)
        {
        }

        protected override string GetExpectedEveryMinute()
        {
            return "Every minute";
        }

        protected override string GetExpectedEvery1Minute()
        {
            return "Every minute";
        }

        protected override string GetExpectedEveryHour()
        {
            return "Every hour";
        }

        protected override string GetExpectedTimeOfDayCertainDaysOfWeek()
        {
            return "At |T0|, Monday through Friday";
        }

        protected override string GetExpectedEverySecond()
        {
            return "Every second";
        }

        protected override string GetExpectedEvery45Seconds()
        {
            return "Every |S0| seconds";
        }

        protected override string GetExpectedEvery5Seconds()
        {
            return "Every |S0| seconds";
        }

        protected override string GetExpectedEvery5Minutes()
        {
            return "Every |M0| minutes";
        }

        protected override string GetExpectedEvery10Minutes()
        {
            return "Every |M0| minutes";
        }

        protected override string GetExpectedEvery5MinutesOnTheSecond()
        {
            return "Every |M0| minutes";
        }

        protected override string GetExpectedWeekdaysAtTime()
        {
            return "At |T0|, Monday through Friday";
        }

        protected override string GetExpectedDailyAtTime()
        {
            return "At |T0|";
        }

        protected override string GetExpectedMinuteSpan()
        {
            return "Every minute between |T0| and |T1|";
        }

        protected override string GetExpectedOneMonthOnly()
        {
            return "Every minute, only in March";
        }

        protected override string GetExpectedTwoMonthsOnly()
        {
            return "Every minute, only in March and June";
        }

        protected override string GetExpectedTwoTimesEachAfternoon()
        {
            return "At |T0| and |T1|";
        }

        protected override string GetExpectedThreeTimesDaily()
        {
            return "At |T0|, |T1| and |T2|";
        }

        protected override string GetExpectedOnceAWeek()
        {
            return "At |T0|, only on Monday";
        }

        protected override string GetExpectedDayOfMonth()
        {
            return "At |T0|, on day |D0| of the month";
        }

        protected override string GetExpectedMonthName()
        {
            return "At |T0|, only in January";
        }

        protected override string GetExpectedDayOfMonthWithQuestionMark()
        {
            return "At |T0|, only in January";
        }

        protected override string GetExpectedMonthNameRange2()
        {
            return "At |T0|, January through February";
        }

        protected override string GetExpectedMonthNameRange3()
        {
            return "At |T0|, January through March";
        }

        protected override string GetExpectedDayOfWeekName()
        {
            return "At |T0|, only on Sunday";
        }

        protected override string GetExpectedDayOfWeekRange()
        {
            return "Every |M0| minutes, at |T0|, Monday through Friday";
        }

        protected override string GetExpectedDayOfWeekOnceInMonth()
        {
            return "Every minute, on the third Monday of the month";
        }

        protected override string GetExpectedLastDayOfTheWeekOfTheMonth()
        {
            return "Every minute, on the last Thursday of the month";
        }

        protected override string GetExpectedLastDayOfTheMonth()
        {
            return "Every |M0| minutes, on the last day of the month, only in January";
        }

        protected override string GetExpectedLastWeekdayOfTheMonth()
        {
            return "Every minute, on the last weekday of the month";
        }

        protected override string GetExpectedLastWeekdayOfTheMonth2()
        {
            return "Every minute, on the last weekday of the month";
        }

        protected override string GetExpectedFirstWeekdayOfTheMonth()
        {
            return "Every minute, on the first weekday of the month";
        }

        protected override string GetExpectedFirstWeekdayOfTheMonth2()
        {
            return "Every minute, on the first weekday of the month";
        }

        protected override string GetExpectedParticularWeekdayOfTheMonth()
        {
            return "Every minute, on the weekday nearest day |D0| of the month";
        }

        protected override string GetExpectedParticularWeekdayOfTheMonth2()
        {
            return "Every minute, on the weekday nearest day |D0| of the month";
        }

        protected override string GetExpectedTimeOfDayWithSeconds()
        {
            return "At |T0|";
        }

        protected override string GetExpectedSecondIntervals()
        {
            return "Seconds |S0| through |S1| past the minute";
        }

        protected override string GetExpectedSecondMinutesHoursIntervals()
        {
            return "Seconds |S0| through |S1| past the minute, minutes |M0| through |M1| past the hour, between |T0| and |T1|";
        }

        protected override string GetExpectedEvery5MinutesAt30Seconds()
        {
            return "At |S0| seconds past the minute, every |M0| minutes";
        }

        protected override string GetExpectedMinutesPastTheHourRange()
        {
            return "At |M0| minutes past the hour, between |T0| and |T1|, only on Wednesday and Friday";
        }

        protected override string GetExpectedSecondsPastTheMinuteInterval()
        {
            return "At |S0| seconds past the minute, every |M0| minutes";
        }

        protected override string GetExpectedBetweenWithInterval()
        {
            return "Every |M0| minutes, minutes |M1| through |M2| past the hour, at |T0|, |T1|, and |T2|, between day |D0| and |D1| of the month, January through June";
        }

        protected override string GetExpectedRecurringFirstOfMonth()
        {
            return "At |T0|";
        }

        protected override string GetExpectedMinutesPastTheHour()
        {
            return "At |M0| minutes past the hour";
        }

        protected override string GetExpectedOneYearOnlyWithSeconds()
        {
            return "Every second, only in |Y0|";
        }

        protected override string GetExpectedOneYearOnlyWithoutSeconds()
        {
            return "Every minute, only in |Y0|";
        }

        protected override string GetExpectedTwoYearsOnly()
        {
            return "Every minute, only in |Y0| and |Y1|";
        }

        protected override string GetExpectedYearRange2()
        {
            return "At |T0|, January through February, |Y0| through |Y1|";
        }

        protected override string GetExpectedYearRange3()
        {
            return "At |T0|, January through March, |Y0| through |Y1|";
        }

        protected override string GetExpectedHourRange()
        {
            return "Every |M0| minutes, between |T0| and |T1|, on day |D0| and |D1| of the month";
        }

        protected override string GetExpectedDayOfWeekModifier()
        {
            return "At |T0|, on the second Sunday of the month";
        }

        protected override string GetExpectedDayOfWeekModifierWithSundayStartOne()
        {
            return "At |T0|, on the second Sunday of the month";
        }

        protected override string GetExpectedHourRangeWithEveryPortion()
        {
            return "At |M0| minutes past the hour, every |H0| hours, between |T0| and |T1|";
        }

        protected override string GetExpectedHourRangeWithTrailingZeroWithEveryPortion()
        {
            return "At |M0| minutes past the hour, every |H0| hours, between |T0| and |T1|";
        }

    }
}