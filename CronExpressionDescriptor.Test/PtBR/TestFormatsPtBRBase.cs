using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CronExpressionDescriptor.Test.PtBR
{
    [TestClass]
    public abstract class TestFormatsPtBRBase : TestFormatBase
    {
        public TestFormatsPtBRBase(FormatsTypeEnum formatsType)
            : base("pt-BR", formatsType)
        {
        }

        protected override string GetExpectedEveryMinute()
        {
            return "A cada minuto";
        }

        protected override string GetExpectedEvery1Minute()
        {
            return "A cada minuto";
        }

        protected override string GetExpectedEveryHour()
        {
            return "A cada hora";
        }

        protected override string GetExpectedTimeOfDayCertainDaysOfWeek()
        {
            return "Às |T0|, de segunda-feira a sexta-feira";
        }

        protected override string GetExpectedEverySecond()
        {
            return "A cada segundo";
        }

        protected override string GetExpectedEvery45Seconds()
        {
            return "A cada |S0| segundos";
        }

        protected override string GetExpectedEvery5Seconds()
        {
            return "A cada |S0| segundos";
        }

        protected override string GetExpectedEvery10Minutes()
        {
            return "A cada |M0| minutos";
        }

        protected override string GetExpectedEvery5Minutes()
        {
            return "A cada |M0| minutos";
        }

        protected override string GetExpectedEvery5MinutesOnTheSecond()
        {
            return "A cada |M0| minutos";
        }

        protected override string GetExpectedWeekdaysAtTime()
        {
            return "Às |T0|, de segunda-feira a sexta-feira";
        }

        protected override string GetExpectedDailyAtTime()
        {
            return "Às |T0|";
        }

        protected override string GetExpectedMinuteSpan()
        {
            return "A cada minuto entre |T0| e |T1|";
        }

        protected override string GetExpectedOneMonthOnly()
        {
            return "A cada minuto, somente em março";
        }

        protected override string GetExpectedTwoMonthsOnly()
        {
            return "A cada minuto, somente em março e junho";
        }

        protected override string GetExpectedTwoTimesEachAfternoon()
        {
            return "Às |T0| e |T1|";
        }

        protected override string GetExpectedThreeTimesDaily()
        {
            return "Às |T0|, |T1| e |T2|";
        }

        protected override string GetExpectedOnceAWeek()
        {
            return "Às |T0|, somente de segunda-feira";
        }

        protected override string GetExpectedDayOfMonth()
        {
            return "Às |T0|, no dia |D0| do mês";
        }

        protected override string GetExpectedMonthName()
        {
            return "Às |T0|, somente em janeiro";
        }

        protected override string GetExpectedDayOfMonthWithQuestionMark()
        {
            return "Às |T0|, somente em janeiro";
        }

        protected override string GetExpectedMonthNameRange2()
        {
            return "Às |T0|, de janeiro a fevereiro";
        }

        protected override string GetExpectedMonthNameRange3()
        {
            return "Às |T0|, de janeiro a março";
        }

        protected override string GetExpectedDayOfWeekName()
        {
            return "Às |T0|, somente de domingo";
        }

        protected override string GetExpectedDayOfWeekRange()
        {
            return "A cada |M0| minutos, Às |T0|, de segunda-feira a sexta-feira";
        }

        protected override string GetExpectedDayOfWeekOnceInMonth()
        {
            return "A cada minuto, na terceira segunda-feira do mês";
        }

        protected override string GetExpectedLastDayOfTheWeekOfTheMonth()
        {
            return "A cada minuto, na última quinta-feira do mês";
        }

        protected override string GetExpectedLastDayOfTheMonth()
        {
            return "A cada |M0| minutos, no último dia do mês, somente em janeiro";
        }

        protected override string GetExpectedLastWeekdayOfTheMonth()
        {
            return "A cada minuto, no último dia da semana do mês";
        }

        protected override string GetExpectedLastWeekdayOfTheMonth2()
        {
            return "A cada minuto, no último dia da semana do mês";
        }

        protected override string GetExpectedFirstWeekdayOfTheMonth()
        {
            return "A cada minuto, no primeiro dia da semana do mês";
        }

        protected override string GetExpectedFirstWeekdayOfTheMonth2()
        {
            return "A cada minuto, no primeiro dia da semana do mês";
        }

        protected override string GetExpectedParticularWeekdayOfTheMonth()
        {
            return "A cada minuto, no dia da semana mais próximo do dia |D0| do mês";
        }

        protected override string GetExpectedParticularWeekdayOfTheMonth2()
        {
            return "A cada minuto, no dia da semana mais próximo do dia |D0| do mês";
        }

        protected override string GetExpectedTimeOfDayWithSeconds()
        {
            return "Às |T0|";
        }

        protected override string GetExpectedSecondIntervals()
        {
            return "No segundo |S0| até |S1| de cada minuto";
        }

        protected override string GetExpectedSecondMinutesHoursIntervals()
        {
            return "No segundo |S0| até |S1| de cada minuto, do minuto |M0| até |M1| de cada hora, entre |T0| e |T1|";
        }

        protected override string GetExpectedEvery5MinutesAt30Seconds()
        {
            return "Aos |S0| segundos do minuto, a cada |M0| minutos";
        }

        protected override string GetExpectedMinutesPastTheHourRange()
        {
            return "Aos |M0| minutos da hora, entre |T0| e |T1|, somente de quarta-feira e sexta-feira";
        }

        protected override string GetExpectedSecondsPastTheMinuteInterval()
        {
            return "Aos |S0| segundos do minuto, a cada |M0| minutos";
        }

        protected override string GetExpectedBetweenWithInterval()
        {
            return "A cada |M0| minutos, do minuto |M1| até |M2| de cada hora, Às |T0|, |T1|, e |T2|, entre os dias |D0| e |D1| do mês, de janeiro a junho";
        }

        protected override string GetExpectedRecurringFirstOfMonth()
        {
            return "Às |T0|";
        }

        protected override string GetExpectedMinutesPastTheHour()
        {
            return "Aos |M0| minutos da hora";
        }

        protected override string GetExpectedOneYearOnlyWithSeconds()
        {
            return "A cada segundo, somente em |Y0|";
        }

        protected override string GetExpectedOneYearOnlyWithoutSeconds()
        {
            return "A cada minuto, somente em |Y0|";
        }

        protected override string GetExpectedTwoYearsOnly()
        {
            return "A cada minuto, somente em |Y0| e |Y1|";
        }

        protected override string GetExpectedYearRange2()
        {
            return "Às |T0|, de janeiro a fevereiro, de |Y0| a |Y1|";
        }

        protected override string GetExpectedYearRange3()
        {
            return "Às |T0|, de janeiro a março, de |Y0| a |Y1|";
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