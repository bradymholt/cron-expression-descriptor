using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.Fr
{
    [TestClass]
    public abstract class TestFormatsFrBase : TestFormatBase
    {
        public TestFormatsFrBase(FormatsTypeEnum formatsType)
            : base("fr", formatsType)
        {
        }

        protected override string GetExpectedEveryMinute()
        {
            return "Toutes les minutes";
        }

        protected override string GetExpectedEvery1Minute()
        {
            return "Toutes les minutes";
        }

        protected override string GetExpectedEveryHour()
        {
            return "Toutes les heures";
        }

        protected override string GetExpectedTimeOfDayCertainDaysOfWeek()
        {
            return "À |T0|, du lundi au vendredi";
        }

        protected override string GetExpectedEverySecond()
        {
            return "Toutes les secondes";
        }

        protected override string GetExpectedEvery45Seconds()
        {
            return "Toutes les |S0| secondes";
        }

        protected override string GetExpectedEvery5Seconds()
        {
            return "Toutes les |S0| secondes";
        }

        protected override string GetExpectedEvery5Minutes()
        {
            return "Toutes les |M0| minutes";
        }

        protected override string GetExpectedEvery10Minutes()
        {
            return "Toutes les |M0| minutes";
        }

        protected override string GetExpectedEvery5MinutesOnTheSecond()
        {
            return "Toutes les |M0| minutes";
        }

        protected override string GetExpectedWeekdaysAtTime()
        {
            return "À |T0|, du lundi au vendredi";
        }

        protected override string GetExpectedDailyAtTime()
        {
            return "À |T0|";
        }

        protected override string GetExpectedMinuteSpan()
        {
            return "Toutes les minutes entre |T0| et |T1|";
        }

        protected override string GetExpectedOneMonthOnly()
        {
            return "Toutes les minutes, uniquement en mars";
        }

        protected override string GetExpectedTwoMonthsOnly()
        {
            return "Toutes les minutes, uniquement en mars et juin";
        }

        protected override string GetExpectedTwoTimesEachAfternoon()
        {
            return "À |T0| et |T1|";
        }

        protected override string GetExpectedThreeTimesDaily()
        {
            return "À |T0|, |T1| et |T2|";
        }

        protected override string GetExpectedOnceAWeek()
        {
            return "À |T0|, uniquement le lundi";
        }

        protected override string GetExpectedDayOfMonth()
        {
            return "À |T0|, le |D0| du mois";
        }

        protected override string GetExpectedMonthName()
        {
            return "À |T0|, uniquement en janvier";
        }

        protected override string GetExpectedDayOfMonthWithQuestionMark()
        {
            return "À |T0|, uniquement en janvier";
        }

        protected override string GetExpectedMonthNameRange2()
        {
            return "À |T0|, de janvier à février";
        }

        protected override string GetExpectedMonthNameRange3()
        {
            return "À |T0|, de janvier à mars";
        }

        protected override string GetExpectedDayOfWeekName()
        {
            return "À |T0|, uniquement le dimanche";
        }

        protected override string GetExpectedDayOfWeekRange()
        {
            return "Toutes les |M0| minutes, à |T0|, du lundi au vendredi";
        }

        protected override string GetExpectedDayOfWeekOnceInMonth()
        {
            return "Toutes les minutes, le troisième lundi du mois";
        }

        protected override string GetExpectedLastDayOfTheWeekOfTheMonth()
        {
            return "Toutes les minutes, le dernier jeudi du mois";
        }

        protected override string GetExpectedLastDayOfTheMonth()
        {
            return "Toutes les |M0| minutes, le dernier jour du mois, uniquement en janvier";
        }

        protected override string GetExpectedLastWeekdayOfTheMonth()
        {
            return "Toutes les minutes, le dernier jour ouvrable du mois";
        }

        protected override string GetExpectedLastWeekdayOfTheMonth2()
        {
            return "Toutes les minutes, le dernier jour ouvrable du mois";
        }

        protected override string GetExpectedFirstWeekdayOfTheMonth()
        {
            return "Toutes les minutes, le premier jour ouvrable du mois";
        }

        protected override string GetExpectedFirstWeekdayOfTheMonth2()
        {
            return "Toutes les minutes, le premier jour ouvrable du mois";
        }

        protected override string GetExpectedParticularWeekdayOfTheMonth()
        {
            return "Toutes les minutes, le jour ouvrable le plus proche du |D0| du mois";
        }

        protected override string GetExpectedParticularWeekdayOfTheMonth2()
        {
            return "Toutes les minutes, le jour ouvrable le plus proche du |D0| du mois";
        }

        protected override string GetExpectedTimeOfDayWithSeconds()
        {
            return "À |T0|";
        }

        protected override string GetExpectedSecondIntervals()
        {
            return "Les secondes entre |S0| et |S1| après la minute";
        }

        protected override string GetExpectedSecondMinutesHoursIntervals()
        {
            return "Les secondes entre |S0| et |S1| après la minute, les minutes entre |M0| et |M1| après l'heure, de |T0| à |T1|";
        }

        protected override string GetExpectedEvery5MinutesAt30Seconds()
        {
            return "|S0| secondes après la minute, toutes les |M0| minutes";
        }

        protected override string GetExpectedMinutesPastTheHourRange()
        {
            return "|M0| minutes après l'heure, de |T0| à |T1|, uniquement le mercredi et le vendredi";
        }

        protected override string GetExpectedSecondsPastTheMinuteInterval()
        {
            return "|S0| secondes après la minute, toutes les |M0| minutes";
        }

        protected override string GetExpectedBetweenWithInterval()
        {
            return "Toutes les |M0| minutes, les minutes entre |M1| et |M2| après l'heure, à |T0|, |T1|, et |T2|, du |D0| au |D1| du mois, de janvier à juin";
        }

        protected override string GetExpectedRecurringFirstOfMonth()
        {
            return "À |T0|";
        }

        protected override string GetExpectedMinutesPastTheHour()
        {
            return "|M0| minutes après l'heure";
        }

        protected override string GetExpectedOneYearOnlyWithSeconds()
        {
            return "Toutes les secondes, uniquement en |Y0|";
        }

        protected override string GetExpectedOneYearOnlyWithoutSeconds()
        {
            return "Toutes les minutes, uniquement en |Y0|";
        }

        protected override string GetExpectedTwoYearsOnly()
        {
            return "Toutes les minutes, uniquement en |Y0| et |Y1|";
        }

        protected override string GetExpectedYearRange2()
        {
            return "À |T0|, de janvier à février, de |Y0| à |Y1|";
        }

        protected override string GetExpectedYearRange3()
        {
            return "À |T0|, de janvier à mars, de |Y0| à |Y1|";
        }

        protected override string GetExpectedHourRange()
        {
            return "Toutes les |M0| minutes, de |T0| à |T1|, le |D0| et le |D1| du mois";
        }

        protected override string GetExpectedDayOfWeekModifier()
        {
            return "À |T0|, le second dimanche du mois";
        }

        protected override string GetExpectedDayOfWeekModifierWithSundayStartOne()
        {
            return "À |T0|, le second dimanche du mois";
        }

        protected override string GetExpectedHourRangeWithEveryPortion()
        {
            return "|M0| minutes après l'heure, toutes les |H0| heures, de |T0| à |T1|";
        }

        protected override string GetExpectedHourRangeWithTrailingZeroWithEveryPortion()
        {
            return "|M0| minutes après l'heure, toutes les |H0| heures, de |T0| à |T1|";
        }


    }
}