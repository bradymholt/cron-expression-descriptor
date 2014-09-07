using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.Es
{
    [TestClass]
    public abstract class TestFormatsEsBase : TestFormatBase
    {
        public TestFormatsEsBase(FormatsTypeEnum formatsType)
            : base("es", formatsType)
        {
        }

        protected override string GetExpectedEveryMinute()
        {
            return "Cada minuto";
        }

        protected override string GetExpectedEvery1Minute()
        {
            return "Cada minuto";
        }

        protected override string GetExpectedEveryHour()
        {
            return "Cada hora";
        }

        protected override string GetExpectedTimeOfDayCertainDaysOfWeek()
        {
            return "A las |T0|, de lunes a viernes";
        }

        protected override string GetExpectedEverySecond()
        {
            return "Cada segundo";
        }

        protected override string GetExpectedEvery45Seconds()
        {
            return "Cada |S0| segundos";
        }

        protected override string GetExpectedEvery5Seconds()
        {
            return "Cada |S0| segundos";
        }

        protected override string GetExpectedEvery5Minutes()
        {
            return "Cada |M0| minutos";
        }
        
        protected override string GetExpectedEvery10Minutes()
        {
            return "Cada |M0| minutos";
        }

        protected override string GetExpectedEvery5MinutesOnTheSecond()
        {
            return "Cada |M0| minutos";
        }

        protected override string GetExpectedWeekdaysAtTime()
        {
            return "A las |T0|, de lunes a viernes";
        }

        protected override string GetExpectedDailyAtTime()
        {
            return "A las |T0|";
        }

        protected override string GetExpectedMinuteSpan()
        {
            return "Cada minuto entre las |T0| y las |T1|";
        }

        protected override string GetExpectedOneMonthOnly()
        {
            return "Cada minuto, sólo en marzo";
        }

        protected override string GetExpectedTwoMonthsOnly()
        {
            return "Cada minuto, sólo en marzo y junio";
        }

        protected override string GetExpectedTwoTimesEachAfternoon()
        {
            return "A las |T0| y |T1|";
        }

        protected override string GetExpectedThreeTimesDaily()
        {
            return "A las |T0|, |T1| y |T2|";
        }

        protected override string GetExpectedOnceAWeek()
        {
            return "A las |T0|, sólo el lunes";
        }

        protected override string GetExpectedDayOfMonth()
        {
            return "A las |T0|, el día |D0| del mes";
        }

        protected override string GetExpectedMonthName()
        {
            return "A las |T0|, sólo en enero";
        }

        protected override string GetExpectedDayOfMonthWithQuestionMark()
        {
            return "A las |T0|, sólo en enero";
        }

        protected override string GetExpectedMonthNameRange2()
        {
            return "A las |T0|, de enero a febrero";
        }

        protected override string GetExpectedMonthNameRange3()
        {
            return "A las |T0|, de enero a marzo";
        }

        protected override string GetExpectedDayOfWeekName()
        {
            return "A las |T0|, sólo el domingo";
        }

        protected override string GetExpectedDayOfWeekRange()
        {
            return "Cada |M0| minutos, a las |T0|, de lunes a viernes";
        }

        protected override string GetExpectedDayOfWeekOnceInMonth()
        {
            return "Cada minuto, en el tercer lunes del mes";
        }

        protected override string GetExpectedLastDayOfTheWeekOfTheMonth()
        {
            return "Cada minuto, en el último jueves del mes";
        }

        protected override string GetExpectedLastDayOfTheMonth()
        {
            return "Cada |M0| minutos, en el último día del mes, sólo en enero";
        }

        protected override string GetExpectedLastWeekdayOfTheMonth()
        {
            return "Cada minuto, en el último día de la semana del mes";
        }

        protected override string GetExpectedLastWeekdayOfTheMonth2()
        {
            return "Cada minuto, en el último día de la semana del mes";
        }

        protected override string GetExpectedFirstWeekdayOfTheMonth()
        {
            return "Cada minuto, en el primer día de la semana del mes";
        }

        protected override string GetExpectedFirstWeekdayOfTheMonth2()
        {
            return "Cada minuto, en el primer día de la semana del mes";
        }

        protected override string GetExpectedParticularWeekdayOfTheMonth()
        {
            return "Cada minuto, en el día de la semana más próximo al |D0| del mes";
        }

        protected override string GetExpectedParticularWeekdayOfTheMonth2()
        {
            return "Cada minuto, en el día de la semana más próximo al |D0| del mes";
        }

        protected override string GetExpectedTimeOfDayWithSeconds()
        {
            return "A las |T0|";
        }

        protected override string GetExpectedSecondIntervals()
        {
            return "En los segundos |S0| al |S1| de cada minuto";
        }

        protected override string GetExpectedSecondMinutesHoursIntervals()
        {
            return "En los segundos |S0| al |S1| de cada minuto, del minuto |M0| al |M1| pasada la hora, entre las |T0| y las |T1|";
        }

        protected override string GetExpectedEvery5MinutesAt30Seconds()
        {
            return "A los |S0| segundos del minuto, cada |M0| minutos";
        }

        protected override string GetExpectedMinutesPastTheHourRange()
        {
            return "A los |M0| minutos de la hora, entre las |T0| y las |T1|, sólo el miércoles y viernes";
        }

        protected override string GetExpectedSecondsPastTheMinuteInterval()
        {
            return "A los |S0| segundos del minuto, cada |M0| minutos";
        }

        protected override string GetExpectedBetweenWithInterval()
        {
            return "Cada |M0| minutos, del minuto |M1| al |M2| pasada la hora, a las |T0|, |T1|, y |T2|, entre los días |D0| y |D1| del mes, de enero a junio";
        }

        protected override string GetExpectedRecurringFirstOfMonth()
        {
            return "A las |T0|";
        }

        protected override string GetExpectedMinutesPastTheHour()
        {
            return "A los |M0| minutos de la hora";
        }

        protected override string GetExpectedOneYearOnlyWithSeconds()
        {
            return "Cada segundo, sólo en |Y0|";
        }

        protected override string GetExpectedOneYearOnlyWithoutSeconds()
        {
            return "Cada minuto, sólo en |Y0|";
        }

        protected override string GetExpectedTwoYearsOnly()
        {
            return "Cada minuto, sólo en |Y0| y |Y1|";
        }

        protected override string GetExpectedYearRange2()
        {
            return "A las |T0|, de enero a febrero, de |Y0| a |Y1|";
        }

        protected override string GetExpectedYearRange3()
        {
            return "A las |T0|, de enero a marzo, de |Y0| a |Y1|";
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