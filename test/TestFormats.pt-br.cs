using Xunit;

namespace CronExpressionDescriptor.Test
{
    /// <summary>
    /// Tests for Portuguese translation
    /// </summary>
    public class TestFormatsPTBR : Support.BaseTestFormats
    {
        protected override string GetLocale()
        {
            return "pt-BR";
        }

        [Fact]
        public void TestEveryMinute()
        {
            Assert.Equal("A cada minuto", GetDescription("* * * * *"));
        }
        [Fact]
        public void TestEvery1Minute()
        {
            Assert.Equal("A cada minuto", GetDescription("*/1 * * * *"));
            Assert.Equal("A cada minuto", GetDescription("0 0/1 * * * ?"));
        }
        [Fact]
        public void TestEveryHour()
        {
            Assert.Equal("A cada hora", GetDescription("0 0 * * * ?"));
            Assert.Equal("A cada hora", GetDescription("0 0 0/1 * * ?"));
        }
        [Fact]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.Equal("Às 11:00 PM, de segunda-feira a sexta-feira", GetDescription("0 23 ? * MON-FRI"));
        }
        [Fact]
        public void TestEverySecond()
        {
            Assert.Equal("A cada segundo", GetDescription("* * * * * *"));
        }
        [Fact]
        public void TestEvery45Seconds()
        {
            Assert.Equal("A cada 45 segundos", GetDescription("*/45 * * * * *"));
        }
        [Fact]
        public void TestEvery5Minutes()
        {
            Assert.Equal("A cada 5 minutos", GetDescription("*/5 * * * *"));
            Assert.Equal("A cada 10 minutos", GetDescription("0 0/10 * * * ?"));
        }
        [Fact]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.Equal("A cada 5 minutos", GetDescription("0 */5 * * * *"));
        }

        [Fact]
        public void TestWeekdaysAtTime()
        {
            Assert.Equal("Às 11:30 AM, de segunda-feira a sexta-feira", GetDescription("30 11 * * 1-5"));
        }

        [Fact]
        public void TestDailyAtTime()
        {
            Assert.Equal("Às 11:30 AM", GetDescription("30 11 * * *"));
        }
        [Fact]
        public void TestMinuteSpan()
        {
            Assert.Equal("A cada minuto entre 11:00 AM e 11:10 AM", GetDescription("0-10 11 * * *"));
        }

        [Fact]
        public void TestOneMonthOnly()
        {
            Assert.Equal("A cada minuto, somente em março", GetDescription("* * * 3 *"));
        }

        [Fact]
        public void TestTwoMonthsOnly()
        {
            Assert.Equal("A cada minuto, somente em março e junho", GetDescription("* * * 3,6 *"));
        }
        [Fact]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.Equal("Às 02:30 PM e 04:30 PM", GetDescription("30 14,16 * * *"));
        }

        [Fact]
        public void TestThreeTimesDaily()
        {
            Assert.Equal("Às 06:30 AM, 02:30 PM e 04:30 PM", GetDescription("30 6,14,16 * * *"));
        }

        [Fact]
        public void TestOnceAWeek()
        {
            Assert.Equal("Às 09:46 AM, somente de segunda-feira", GetDescription("46 9 * * 1"));
        }
        [Fact]
        public void TestDayOfMonth()
        {
            Assert.Equal("Às 12:23 PM, no dia 15 do mês", GetDescription("23 12 15 * *"));
        }

        [Fact]
        public void TestMonthName()
        {
            Assert.Equal("Às 12:23 PM, somente em janeiro", GetDescription("23 12 * JAN *"));
        }

        [Fact]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.Equal("Às 12:23 PM, somente em janeiro", GetDescription("23 12 ? JAN *"));
        }
        [Fact]
        public void TestMonthNameRange2()
        {
            Assert.Equal("Às 12:23 PM, de janeiro a fevereiro", GetDescription("23 12 * JAN-FEB *"));
        }

        [Fact]
        public void TestMonthNameRange3()
        {
            Assert.Equal("Às 12:23 PM, de janeiro a março", GetDescription("23 12 * JAN-MAR *"));
        }

        [Fact]
        public void TestDayOfWeekName()
        {
            Assert.Equal("Às 12:23 PM, somente de domingo", GetDescription("23 12 * * SUN"));
        }
        [Fact]
        public void TestDayOfWeekRange()
        {
            Assert.Equal("A cada 5 minutos, entre 03:00 PM e 03:59 PM, de segunda-feira a sexta-feira", GetDescription("*/5 15 * * MON-FRI"));
        }

        [Fact]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.Equal("A cada minuto, na terceira segunda-feira do mês", GetDescription("* * * * MON#3"));
        }

        [Fact]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.Equal("A cada minuto, na última quinta-feira do mês", GetDescription("* * * * 4L"));
        }
        [Fact]
        public void TestLastDayOfTheMonth()
        {
            Assert.Equal("A cada 5 minutos, no último dia do mês, somente em janeiro", GetDescription("*/5 * L JAN *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.Equal("A cada minuto, no último dia da semana do mês", GetDescription("* * LW * *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.Equal("A cada minuto, no último dia da semana do mês", GetDescription("* * WL * *"));
        }
        [Fact]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.Equal("A cada minuto, no primeiro dia da semana do mês", GetDescription("* * 1W * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.Equal("A cada minuto, no primeiro dia da semana do mês", GetDescription("* * W1 * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.Equal("A cada minuto, no dia da semana mais próximo do dia 5 do mês", GetDescription("* * 5W * *"));
        }
        [Fact]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.Equal("A cada minuto, no dia da semana mais próximo do dia 5 do mês", GetDescription("* * W5 * *"));
        }

        [Fact]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.Equal("Às 02:02:30 PM", GetDescription("30 02 14 * * *"));
        }

        [Fact]
        public void TestSecondInternvals()
        {
            Assert.Equal("No segundo 5 até 10 de cada minuto", GetDescription("5-10 * * * * *"));
        }
        [Fact]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.Equal("No segundo 5 até 10 de cada minuto, do minuto 30 até 35 de cada hora, entre 10:00 AM e 12:59 PM", GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Fact]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.Equal("Aos 30 segundos do minuto, a cada 5 minutos", GetDescription("30 */5 * * * *"));
        }

        [Fact]
        public void TestMinutesPastTheHourRange()
        {
            Assert.Equal("Aos 30 minutos da hora, entre 10:00 AM e 01:59 PM, somente de quarta-feira e sexta-feira", GetDescription("0 30 10-13 ? * WED,FRI"));
        }
        [Fact]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.Equal("Aos 10 segundos do minuto, a cada 5 minutos", GetDescription("10 0/5 * * * ?"));
        }
        [Fact]
        public void TestBetweenWithInterval()
        {
            Assert.Equal("A cada 3 minutos, do minuto 2 até 59 de cada hora, Às 01:00 AM, 09:00 AM, e 10:00 PM, entre os dias 11 e 26 do mês, de janeiro a junho", GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }
        [Fact]
        public void TestRecurringFirstOfMonth()
        {
            Assert.Equal("Às 06:00 AM", GetDescription("0 0 6 1/1 * ?"));
        }
        [Fact]
        public void TestMinutesPastTheHour()
        {
            Assert.Equal("Aos 5 minutos da hora", GetDescription("0 5 0/1 * * ?"));
        }
        [Fact]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.Equal("A cada segundo, somente em 2013", GetDescription("* * * * * * 2013"));
        }

        [Fact]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.Equal("A cada minuto, somente em 2013", GetDescription("* * * * * 2013"));
        }

        [Fact]
        public void TestTwoYearsOnly()
        {
            Assert.Equal("A cada minuto, somente em 2013 e 2014", GetDescription("* * * * * 2013,2014"));
        }

        [Fact]
        public void TestYearRange2()
        {
            Assert.Equal("Às 12:23 PM, de janeiro a fevereiro, de 2013 a 2014", GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Fact]
        public void TestYearRange3()
        {
            Assert.Equal("Às 12:23 PM, de janeiro a março, de 2013 a 2015", GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Fact]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
            Assert.Equal("A cada 30 segundos, iniciando aos 5 segundos do minuto", GetDescription("5/30 * * * * ?"));
        }

        [Fact]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.Equal("A cada 30 minutos, iniciando aos 5 minutos da hora", GetDescription("0 5/30 * * * ?"));
        }

        [Fact]
        public void TestHoursInternalWithStepValue()
        {
            Assert.Equal("A cada segundo, a cada 8 horas, iniciando Às 05:00 AM", GetDescription("* * 5/8 * * ?"));
        }

        [Fact]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.Equal("Às 07:05 AM, a cada 3 dias, iniciando no dia 2 do mês", GetDescription("0 5 7 2/3 * ? *"));
        }

        [Fact]
        public void TestMonthInternalWithStepValue()
        {
            Assert.Equal("Às 07:05 AM, a cada 2 meses, de março a dezembro", GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Fact]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.Equal("Às 07:05 AM, a cada 3 dias de semana, de terça-feira a sábado", GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Fact]
        public void TestYearInternalWithStepValue()
        {
            Assert.Equal("Às 07:05 AM, a cada 4 anos, de 2016 a 9999", GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}
