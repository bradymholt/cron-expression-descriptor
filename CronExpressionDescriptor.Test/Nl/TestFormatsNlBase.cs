using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.Nl
{
    [TestClass]
    public abstract class TestFormatsNlBase : TestFormatBase
    {
        public TestFormatsNlBase(FormatsTypeEnum formatsType)
            : base("nl", formatsType)
        {
        }

        protected override string GetExpectedEveryMinute()
        {
            return "Elke minuut";
        }

        protected override string GetExpectedEvery1Minute()
        {
            return "Elke minuut";
        }

        protected override string GetExpectedEveryHour()
        {
            return "Elk uur";
        }

        protected override string GetExpectedTimeOfDayCertainDaysOfWeek()
        {
            return "Op |T0|, maandag t/m vrijdag";
        }

        protected override string GetExpectedEverySecond()
        {
            return "Elke seconde";
        }

        protected override string GetExpectedEvery45Seconds()
        {
            return "Elke |S0| seconden";
        }

        protected override string GetExpectedEvery5Seconds()
        {
            return "Elke |S0| seconden";
        }

        protected override string GetExpectedEvery5Minutes()
        {
            return "Elke |M0| minuten";
        }
        
        protected override string GetExpectedEvery10Minutes()
        {
            return "Elke |M0| minuten";
        }

        protected override string GetExpectedEvery5MinutesOnTheSecond()
        {
            return "Elke |M0| minuten";
        }

        protected override string GetExpectedWeekdaysAtTime()
        {
            return "Op |T0|, maandag t/m vrijdag";
        }

        protected override string GetExpectedDailyAtTime()
        {
            return "Op |T0|";
        }

        protected override string GetExpectedMinuteSpan()
        {
            return "Elke minuut tussen |T0| en |T1|";
        }

        protected override string GetExpectedOneMonthOnly()
        {
            return "Elke minuut, alleen in maart";
        }

        protected override string GetExpectedTwoMonthsOnly()
        {
            return "Elke minuut, alleen in maart en juni";
        }

        protected override string GetExpectedTwoTimesEachAfternoon()
        {
            return "Op |T0| en |T1|";
        }

        protected override string GetExpectedThreeTimesDaily()
        {
            return "Op |T0|, |T1| en |T2|";
        }

        protected override string GetExpectedOnceAWeek()
        {
            return "Op |T0|, alleen op maandag";
        }

        protected override string GetExpectedDayOfMonth()
        {
            return "Op |T0|, op dag |D0| van de maand";
        }

        protected override string GetExpectedMonthName()
        {
            return "Op |T0|, alleen in januari";
        }

        protected override string GetExpectedDayOfMonthWithQuestionMark()
        {
            return "Op |T0|, alleen in januari";
        }

        protected override string GetExpectedMonthNameRange2()
        {
            return "Op |T0|, januari t/m februari";
        }

        protected override string GetExpectedMonthNameRange3()
        {
            return "Op |T0|, januari t/m maart";
        }

        protected override string GetExpectedDayOfWeekName()
        {
            return "Op |T0|, alleen op zondag";
        }

        protected override string GetExpectedDayOfWeekRange()
        {
            return "Elke |M0| minuten, op |T0|, maandag t/m vrijdag";
        }

        protected override string GetExpectedDayOfWeekOnceInMonth()
        {
            return "Elke minuut, op de derde maandag van de maand";
        }

        protected override string GetExpectedLastDayOfTheWeekOfTheMonth()
        {
            return "Elke minuut, op de laatste donderdag van de maand";
        }

        protected override string GetExpectedLastDayOfTheMonth()
        {
            return "Elke |M0| minuten, op de laatste dag van de maand, alleen in januari";
        }

        protected override string GetExpectedLastWeekdayOfTheMonth()
        {
            return "Elke minuut, op de laatste werkdag van de maand";
        }

        protected override string GetExpectedLastWeekdayOfTheMonth2()
        {
            return "Elke minuut, op de laatste werkdag van de maand";
        }

        protected override string GetExpectedFirstWeekdayOfTheMonth()
        {
            return "Elke minuut, op de eerste werkdag van de maand";
        }

        protected override string GetExpectedFirstWeekdayOfTheMonth2()
        {
            return "Elke minuut, op de eerste werkdag van de maand";
        }

        protected override string GetExpectedParticularWeekdayOfTheMonth()
        {
            return "Elke minuut, op de werkdag dichtst bij dag |D0| van de maand";
        }

        protected override string GetExpectedParticularWeekdayOfTheMonth2()
        {
            return "Elke minuut, op de werkdag dichtst bij dag |D0| van de maand";
        }

        protected override string GetExpectedTimeOfDayWithSeconds()
        {
            return "Op |T0|";
        }

        protected override string GetExpectedSecondIntervals()
        {
            return "Seconden |S0| t/m |S1| na de minuut";
        }

        protected override string GetExpectedSecondMinutesHoursIntervals()
        {
            return "Seconden |S0| t/m |S1| na de minuut, minuut |M0| t/m |M1| na het uur, tussen |T0| en |T1|";
        }

        protected override string GetExpectedEvery5MinutesAt30Seconds()
        {
            return "Op |S0| seconden na de minuut, elke |M0| minuten";
        }

        protected override string GetExpectedMinutesPastTheHourRange()
        {
            return "Op |M0| minuten na het uur, tussen |T0| en |T1|, alleen op woensdag en vrijdag";
        }

        protected override string GetExpectedSecondsPastTheMinuteInterval()
        {
            return "Op |S0| seconden na de minuut, elke |M0| minuten";
        }

        protected override string GetExpectedBetweenWithInterval()
        {
            return "Elke |M0| minuten, minuut |M1| t/m |M2| na het uur, op |T0|, |T1|, en |T2|, tussen dag |D0| en |D1| van de maand, januari t/m juni";
        }

        protected override string GetExpectedRecurringFirstOfMonth()
        {
            return "Op |T0|";
        }

        protected override string GetExpectedMinutesPastTheHour()
        {
            return "Op |M0| minuten na het uur";
        }

        protected override string GetExpectedOneYearOnlyWithSeconds()
        {
            return "Elke seconde, alleen in |Y0|";
        }

        protected override string GetExpectedOneYearOnlyWithoutSeconds()
        {
            return "Elke minuut, alleen in |Y0|";
        }

        protected override string GetExpectedTwoYearsOnly()
        {
            return "Elke minuut, alleen in |Y0| en |Y1|";
        }

        protected override string GetExpectedYearRange2()
        {
            return "Op |T0|, januari t/m februari, |Y0| t/m |Y1|";
        }

        protected override string GetExpectedYearRange3()
        {
            return "Op |T0|, januari t/m maart, |Y0| t/m |Y1|";
        }

        protected override string GetExpectedHourRange()
        {
            return "Elke |M0| minuten, tussen |T0| en |T1|, op dag |D0| en |D1| van de maand";
        }

        protected override string GetExpectedDayOfWeekModifier()
        {
            return "Op |T0|, op de tweede zondag van de maand";
        }

        protected override string GetExpectedDayOfWeekModifierWithSundayStartOne()
        {
            return "Op |T0|, op de tweede zondag van de maand";
        }

        protected override string GetExpectedHourRangeWithEveryPortion()
        {
            return "Op |M0| minuten na het uur, elke |H0| uur, tussen |T0| en |T1|";
        }

        protected override string GetExpectedHourRangeWithTrailingZeroWithEveryPortion()
        {
            return "Op |M0| minuten na het uur, elke |H0| uur, tussen |T0| en |T1|";
        }

    }
}