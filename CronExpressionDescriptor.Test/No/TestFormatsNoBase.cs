using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.No
{
    [TestClass]
    public abstract class TestFormatsNoBase : TestFormatBase
    {
        public TestFormatsNoBase(FormatsTypeEnum formatsType)
            : base("no", formatsType)
        {
        }

        protected override string GetExpectedEveryMinute()
        {
            return "Hvert minutt";
        }

        protected override string GetExpectedEvery1Minute()
        {
            return "Hvert minutt";
        }

        protected override string GetExpectedEveryHour()
        {
            return "Hver time";
        }

        protected override string GetExpectedTimeOfDayCertainDaysOfWeek()
        {
            return "På |T0|, mandag til og med fredag";
        }

        protected override string GetExpectedEverySecond()
        {
            return "Hvert sekund";
        }

        protected override string GetExpectedEvery45Seconds()
        {
            return "Hvert |S0| sekund";
        }

        protected override string GetExpectedEvery5Seconds()
        {
            return "Hvert |S0| sekund";
        }

        protected override string GetExpectedEvery5Minutes()
        {
            return "Hvert |M0| minutt";
        }

        protected override string GetExpectedEvery10Minutes()
        {
            return "Hvert |M0| minutt";
        }

        protected override string GetExpectedEvery5MinutesOnTheSecond()
        {
            return "Hvert |M0| minutt";
        }

        protected override string GetExpectedWeekdaysAtTime()
        {
            return "På |T0|, mandag til og med fredag";
        }

        protected override string GetExpectedDailyAtTime()
        {
            return "På |T0|";
        }

        protected override string GetExpectedMinuteSpan()
        {
            return "Hvert minutt mellom |T0| og |T1|";
        }

        protected override string GetExpectedOneMonthOnly()
        {
            return "Hvert minutt, bare i mars";
        }

        protected override string GetExpectedTwoMonthsOnly()
        {
            return "Hvert minutt, bare i mars og juni";
        }

        protected override string GetExpectedTwoTimesEachAfternoon()
        {
            return "På |T0| og |T1|";
        }

        protected override string GetExpectedThreeTimesDaily()
        {
            return "På |T0|, |T1| og |T2|";
        }

        protected override string GetExpectedOnceAWeek()
        {
            return "På |T0|, bare på mandag";
        }

        protected override string GetExpectedDayOfMonth()
        {
            return "På |T0|, på dag |D0| av måneden";
        }

        protected override string GetExpectedMonthName()
        {
            return "På |T0|, bare i januar";
        }

        protected override string GetExpectedDayOfMonthWithQuestionMark()
        {
            return "På |T0|, bare i januar";
        }

        protected override string GetExpectedMonthNameRange2()
        {
            return "På |T0|, januar til og med februar";
        }

        protected override string GetExpectedMonthNameRange3()
        {
            return "På |T0|, januar til og med mars";
        }

        protected override string GetExpectedDayOfWeekName()
        {
            return "På |T0|, bare på søndag";
        }

        protected override string GetExpectedDayOfWeekRange()
        {
            return "Hvert |M0| minutt, på |T0|, mandag til og med fredag";
        }

        protected override string GetExpectedDayOfWeekOnceInMonth()
        {
            return "Hvert minutt, på den tredje mandag av måneden";
        }

        protected override string GetExpectedLastDayOfTheWeekOfTheMonth()
        {
            return "Hvert minutt, på den siste torsdag av måneden";
        }

        protected override string GetExpectedLastDayOfTheMonth()
        {
            return "Hvert |M0| minutt, på den siste dagen i måneden, bare i januar";
        }

        protected override string GetExpectedLastWeekdayOfTheMonth()
        {
            return "Hvert minutt, på den siste ukedagen i måneden";
        }

        protected override string GetExpectedLastWeekdayOfTheMonth2()
        {
            return "Hvert minutt, på den siste ukedagen i måneden";
        }

        protected override string GetExpectedFirstWeekdayOfTheMonth()
        {
            return "Hvert minutt, på den første ukedag av måneden";
        }

        protected override string GetExpectedFirstWeekdayOfTheMonth2()
        {
            return "Hvert minutt, på den første ukedag av måneden";
        }

        protected override string GetExpectedParticularWeekdayOfTheMonth()
        {
            return "Hvert minutt, på den ukedag nærmest dag |D0| av måneden";
        }

        protected override string GetExpectedParticularWeekdayOfTheMonth2()
        {
            return "Hvert minutt, på den ukedag nærmest dag |D0| av måneden";
        }

        protected override string GetExpectedTimeOfDayWithSeconds()
        {
            return "På |T0|";
        }

        protected override string GetExpectedSecondIntervals()
        {
            return "Sekundene fra |S0| til og med |S1| etter minuttet";
        }

        protected override string GetExpectedSecondMinutesHoursIntervals()
        {
            return "Sekundene fra |S0| til og med |S1| etter minuttet, minuttene fra |M0| til og med |M1| etter timen, mellom |T0| og |T1|";
        }

        protected override string GetExpectedEvery5MinutesAt30Seconds()
        {
            return "På |S0| sekunder etter minuttet, hvert |M0| minutt";
        }

        protected override string GetExpectedMinutesPastTheHourRange()
        {
            return "På |M0| minutter etter timen, mellom |T0| og |T1|, bare på onsdag og fredag";
        }

        protected override string GetExpectedSecondsPastTheMinuteInterval()
        {
            return "På |S0| sekunder etter minuttet, hvert |M0| minutt";
        }

        protected override string GetExpectedBetweenWithInterval()
        {
            return "Hvert |M0| minutt, minuttene fra |M1| til og med |M2| etter timen, på |T0|, |T1|, og |T2|, mellom dag |D0| og |D1| av måneden, januar til og med juni";
        }

        protected override string GetExpectedRecurringFirstOfMonth()
        {
            return "På |T0|";
        }

        protected override string GetExpectedMinutesPastTheHour()
        {
            return "På |M0| minutter etter timen";
        }

        protected override string GetExpectedOneYearOnlyWithSeconds()
        {
            return "Hvert sekund, bare i |Y0|";
        }

        protected override string GetExpectedOneYearOnlyWithoutSeconds()
        {
            return "Hvert minutt, bare i |Y0|";
        }

        protected override string GetExpectedTwoYearsOnly()
        {
            return "Hvert minutt, bare i |Y0| og |Y1|";
        }

        protected override string GetExpectedYearRange2()
        {
            return "På |T0|, januar til og med februar, |Y0| til og med |Y1|";
        }

        protected override string GetExpectedYearRange3()
        {
            return "På |T0|, januar til og med mars, |Y0| til og med |Y1|";
        }

        protected override string GetExpectedHourRange()
        {
            return null;
        }

        protected override string GetExpectedDayOfWeekModifier()
        {
            return null;
        }

        protected override string GetExpectedDayOfWeekModifierWithSundayStartOne()
        {
            return null;
        }

        protected override string GetExpectedHourRangeWithEveryPortion()
        {
            return null;
        }

        protected override string GetExpectedHourRangeWithTrailingZeroWithEveryPortion()
        {
            return null;
        }
    }
}