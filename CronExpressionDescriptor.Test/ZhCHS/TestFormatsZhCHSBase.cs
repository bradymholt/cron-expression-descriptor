using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.ZhCHS
{
    [TestClass]
    public abstract class TestFormatsZhCHSBase : TestFormatBase
    {
        protected TestFormatsZhCHSBase(FormatsTypeEnum formatsType)
            : base("zh-CHS", formatsType)
        {
        }

        protected override string GetExpectedEveryMinute()
        {
            return "每分钟";
        }

        protected override string GetExpectedEvery1Minute()
        {
            return "每分钟";
        }

        protected override string GetExpectedEveryHour()
        {
            return "每小时";
        }

        protected override string GetExpectedTimeOfDayCertainDaysOfWeek()
        {
            return "在 |T0|, 星期一 到 星期五";
        }

        protected override string GetExpectedEverySecond()
        {
            return "每秒";
        }

        protected override string GetExpectedEvery45Seconds()
        {
            return "每 |S0| 秒";
        }

        protected override string GetExpectedEvery5Seconds()
        {
            return "每 |S0| 秒";
        }

        protected override string GetExpectedEvery5Minutes()
        {
            return "每 |M0| 分钟";
        }

        protected override string GetExpectedEvery10Minutes()
        {
            return "每 |M0| 分钟";
        }

        protected override string GetExpectedEvery5MinutesOnTheSecond()
        {
            return "每 |M0| 分钟";
        }

        protected override string GetExpectedWeekdaysAtTime()
        {
            return "在 |T0|, 星期一 到 星期五";
        }

        protected override string GetExpectedDailyAtTime()
        {
            return "在 |T0|";
        }

        protected override string GetExpectedMinuteSpan()
        {
            return "在 |T0| 和 |T1| 之间的每分钟";
        }

        protected override string GetExpectedOneMonthOnly()
        {
            return "每分钟, 仅在 三月";
        }

        protected override string GetExpectedTwoMonthsOnly()
        {
            return "每分钟, 仅在 三月 和 六月";
        }

        protected override string GetExpectedTwoTimesEachAfternoon()
        {
            return "在 |T0| 和 |T1|";
        }

        protected override string GetExpectedThreeTimesDaily()
        {
            return "在 |T0|, |T1| 和 |T2|";
        }

        protected override string GetExpectedOnceAWeek()
        {
            return "在 |T0|, 仅在 星期一";
        }

        protected override string GetExpectedDayOfMonth()
        {
            return "在 |T0|, 每月的 |D0| 号";
        }

        protected override string GetExpectedMonthName()
        {
            return "在 |T0|, 仅在 一月";
        }

        protected override string GetExpectedDayOfMonthWithQuestionMark()
        {
            return "在 |T0|, 仅在 一月";
        }

        protected override string GetExpectedMonthNameRange2()
        {
            return "在 |T0|, 一月 到 二月";
        }

        protected override string GetExpectedMonthNameRange3()
        {
            return "在 |T0|, 一月 到 三月";
        }

        protected override string GetExpectedDayOfWeekName()
        {
            return "在 |T0|, 仅在 星期日";
        }

        protected override string GetExpectedDayOfWeekRange()
        {
            return "每 |M0| 分钟, 在 |T0|, 星期一 到 星期五";
        }

        protected override string GetExpectedDayOfWeekOnceInMonth()
        {
            return "每分钟, 在 第三个星期一 每月";
        }

        protected override string GetExpectedLastDayOfTheWeekOfTheMonth()
        {
            return "每分钟, 每月的最后一个 星期四 ";
        }

        protected override string GetExpectedLastDayOfTheMonth()
        {
            return "每 |M0| 分钟, 每月的最后一天, 仅在 一月";
        }

        protected override string GetExpectedLastWeekdayOfTheMonth()
        {
            return "每分钟, 每月的最后一个平日";
        }

        protected override string GetExpectedLastWeekdayOfTheMonth2()
        {
            return "每分钟, 每月的最后一个平日";
        }

        protected override string GetExpectedFirstWeekdayOfTheMonth()
        {
            return "每分钟, 每月的 第一个平日 ";
        }

        protected override string GetExpectedFirstWeekdayOfTheMonth2()
        {
            return "每分钟, 每月的 第一个平日 ";
        }

        protected override string GetExpectedParticularWeekdayOfTheMonth()
        {
            return "每分钟, 每月的 最接近 |D0| 号的平日 ";
        }

        protected override string GetExpectedParticularWeekdayOfTheMonth2()
        {
            return "每分钟, 每月的 最接近 |D0| 号的平日 ";
        }

        protected override string GetExpectedTimeOfDayWithSeconds()
        {
            return "在 |T0|";
        }

        protected override string GetExpectedSecondIntervals()
        {
            return "在每分钟的 |S0| 到 |S1| 秒";
        }

        protected override string GetExpectedSecondMinutesHoursIntervals()
        {
            return "在每分钟的 |S0| 到 |S1| 秒, 在每小时的 |M0| 到 |M1| 分钟, 在 |T0| 和 |T1| 之间";
        }

        protected override string GetExpectedEvery5MinutesAt30Seconds()
        {
            return "在每分钟的 |S0| 秒, 每 |M0| 分钟";
        }

        protected override string GetExpectedMinutesPastTheHourRange()
        {
            return "在每小时的 |M0| 分, 在 |T0| 和 |T1| 之间, 仅在 星期三 和 星期五";
        }

        protected override string GetExpectedSecondsPastTheMinuteInterval()
        {
            return "在每分钟的 |S0| 秒, 每 |M0| 分钟";
        }

        protected override string GetExpectedBetweenWithInterval()
        {
            return "每 |M0| 分钟, 在每小时的 |M1| 到 |M2| 分钟, 在 |T0|, |T1|, 和 |T2|, 在每月的 |D0| 和 |D1| 号之间, 一月 到 六月";
        }

        protected override string GetExpectedRecurringFirstOfMonth()
        {
            return "在 |T0|";
        }

        protected override string GetExpectedMinutesPastTheHour()
        {
            return "在每小时的 |M0| 分";
        }

        protected override string GetExpectedOneYearOnlyWithSeconds()
        {
            return "每秒, 仅在 |Y0|";
        }

        protected override string GetExpectedOneYearOnlyWithoutSeconds()
        {
            return "每分钟, 仅在 |Y0|";
        }

        protected override string GetExpectedTwoYearsOnly()
        {
            return "每分钟, 仅在 |Y0| 和 |Y1|";
        }

        protected override string GetExpectedYearRange2()
        {
            return "在 |T0|, 一月 到 二月, |Y0| 到 |Y1|";
        }

        protected override string GetExpectedYearRange3()
        {
            return "在 |T0|, 一月 到 三月, |Y0| 到 |Y1|";
        }

        protected override string GetExpectedHourRange()
        {
            return "每 |M0| 分钟, 在 |T0| 和 |T1| 之间, 每月的 |D0| 和 |D1| 号";
        }

        protected override string GetExpectedDayOfWeekModifier()
        {
            return "在 |T0|, 在 第二个星期日 每月";
        }

        protected override string GetExpectedDayOfWeekModifierWithSundayStartOne()
        {
            return "在 |T0|, 在 第二个星期日 每月";
        }

        protected override string GetExpectedHourRangeWithEveryPortion()
        {
            return "在每小时的 |M0| 分, 每 |H0| 小时, 在 |T0| 和 |T1| 之间";
        }

        protected override string GetExpectedHourRangeWithTrailingZeroWithEveryPortion()
        {
            return "在每小时的 |M0| 分, 每 |H0| 小时, 在 |T0| 和 |T1| 之间";
        }
    }
}