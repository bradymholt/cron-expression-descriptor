using Xunit;
using Assert = CronExpressionDescriptor.Test.Support.AssertExtensions;

namespace CronExpressionDescriptor.Test
{
    /// <summary>
    /// Tests for Spanish translation
    /// </summary>
    public class TestFormatsES : Support.BaseTestFormats
    {
        protected override string GetLocale()
        {
            return "es-ES";
        }

        [Fact]
        public void TestEveryMinute()
        {
            Assert.EqualsCaseInsensitive("Cada minuto", GetDescription("* * * * *"));
        }

        [Fact]
        public void TestEvery1Minute()
        {
            Assert.EqualsCaseInsensitive("Cada minuto", GetDescription("*/1 * * * *"));
            Assert.EqualsCaseInsensitive("Cada minuto", GetDescription("0 0/1 * * * ?"));
        }

        [Fact]
        public void TestEveryHour()
        {
            Assert.EqualsCaseInsensitive("Cada hora", GetDescription("0 0 * * * ?"));
            Assert.EqualsCaseInsensitive("Cada hora", GetDescription("0 0 0/1 * * ?"));
        }

        [Fact]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.EqualsCaseInsensitive("A las 11:00 PM, de lunes a viernes", GetDescription("0 23 ? * MON-FRI"));
        }

        [Fact]
        public void TestEverySecond()
        {
            Assert.EqualsCaseInsensitive("Cada segundo", GetDescription("* * * * * *"));
        }

        [Fact]
        public void TestEvery45Seconds()
        {
            Assert.EqualsCaseInsensitive("Cada 45 segundos", GetDescription("*/45 * * * * *"));
        }

        [Fact]
        public void TestEvery5Minutes()
        {
            Assert.EqualsCaseInsensitive("Cada 5 minutos", GetDescription("*/5 * * * *"));
            Assert.EqualsCaseInsensitive("Cada 10 minutos", GetDescription("0 0/10 * * * ?"));
        }

        [Fact]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.EqualsCaseInsensitive("Cada 5 minutos", GetDescription("0 */5 * * * *"));
        }

        [Fact]
        public void TestWeekdaysAtTime()
        {
            Assert.EqualsCaseInsensitive("A las 11:30 AM, de lunes a viernes", GetDescription("30 11 * * 1-5"));
        }

        [Fact]
        public void TestDailyAtTime()
        {
            Assert.EqualsCaseInsensitive("A las 11:30 AM", GetDescription("30 11 * * *"));
        }

        [Fact]
        public void TestMinuteSpan()
        {
            Assert.EqualsCaseInsensitive("Cada minuto entre las 11:00 AM y las 11:10 AM", GetDescription("0-10 11 * * *"));
        }

        [Fact]
        public void TestOneMonthOnly()
        {
            Assert.EqualsCaseInsensitive("Cada minuto, sólo en marzo", GetDescription("* * * 3 *"));
        }

        [Fact]
        public void TestTwoMonthsOnly()
        {
            Assert.EqualsCaseInsensitive("Cada minuto, sólo en marzo y junio", GetDescription("* * * 3,6 *"));
        }

        [Fact]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.EqualsCaseInsensitive("A las 02:30 PM y 04:30 PM", GetDescription("30 14,16 * * *"));
        }

        [Fact]
        public void TestThreeTimesDaily()
        {
            Assert.EqualsCaseInsensitive("A las 06:30 AM, 02:30 PM y 04:30 PM", GetDescription("30 6,14,16 * * *"));
        }

        [Fact]
        public void TestOnceAWeek()
        {
            Assert.EqualsCaseInsensitive("A las 09:46 AM, sólo el lunes", GetDescription("46 9 * * 1"));
        }

        [Fact]
        public void TestDayOfMonth()
        {
            Assert.EqualsCaseInsensitive("A las 12:23 PM, el día 15 del mes", GetDescription("23 12 15 * *"));
        }

        [Fact]
        public void TestMonthName()
        {
            Assert.EqualsCaseInsensitive("A las 12:23 PM, sólo en enero", GetDescription("23 12 * JAN *"));
        }


        [Fact]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.EqualsCaseInsensitive("A las 12:23 PM, sólo en enero", GetDescription("23 12 ? JAN *"));
        }

        [Fact]
        public void TestMonthNameRange2()
        {
            Assert.EqualsCaseInsensitive("A las 12:23 PM, de enero a febrero", GetDescription("23 12 * JAN-FEB *"));
        }

        [Fact]
        public void TestMonthNameRange3()
        {
            Assert.EqualsCaseInsensitive("A las 12:23 PM, de enero a marzo", GetDescription("23 12 * JAN-MAR *"));
        }

        [Fact]
        public void TestDayOfWeekName()
        {
            Assert.EqualsCaseInsensitive("A las 12:23 PM, sólo el domingo", GetDescription("23 12 * * SUN"));
        }

        [Fact]
        public void TestDayOfWeekRange()
        {
            Assert.EqualsCaseInsensitive("Cada 5 minutos, entre las 03:00 PM y las 03:59 PM, de lunes a viernes", GetDescription("*/5 15 * * MON-FRI"));
        }

        [Fact]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.EqualsCaseInsensitive("Cada minuto, en el tercer lunes del mes", GetDescription("* * * * MON#3"));
        }

        [Fact]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Cada minuto, en el último jueves del mes", GetDescription("* * * * 4L"));
        }

        [Fact]
        public void TestLastDayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Cada 5 minutos, en el último día del mes, sólo en enero", GetDescription("*/5 * L JAN *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Cada minuto, en el último día de la semana del mes", GetDescription("* * LW * *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.EqualsCaseInsensitive("Cada minuto, en el último día de la semana del mes", GetDescription("* * WL * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Cada minuto, en el primer día de la semana del mes", GetDescription("* * 1W * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.EqualsCaseInsensitive("Cada minuto, en el primer día de la semana del mes", GetDescription("* * W1 * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.EqualsCaseInsensitive("Cada minuto, en el día de la semana más próximo al 5 del mes", GetDescription("* * 5W * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.EqualsCaseInsensitive("Cada minuto, en el día de la semana más próximo al 5 del mes", GetDescription("* * W5 * *"));
        }

        [Fact]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.EqualsCaseInsensitive("A las 02:02:30 PM", GetDescription("30 02 14 * * *"));
        }

        [Fact]
        public void TestSecondInternvals()
        {
            Assert.EqualsCaseInsensitive("En los segundos 5 al 10 de cada minuto", GetDescription("5-10 * * * * *"));
        }

        [Fact]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.EqualsCaseInsensitive("En los segundos 5 al 10 de cada minuto, del minuto 30 al 35 pasada la hora, entre las 10:00 AM y las 12:59 PM", GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Fact]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.EqualsCaseInsensitive("A los 30 segundos del minuto, cada 5 minutos", GetDescription("30 */5 * * * *"));
        }

        [Fact]
        public void TestMinutesPastTheHourRange()
        {
            Assert.EqualsCaseInsensitive("A los 30 minutos de la hora, entre las 10:00 AM y las 01:59 PM, sólo el miércoles y viernes", GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Fact]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.EqualsCaseInsensitive("A los 10 segundos del minuto, cada 5 minutos", GetDescription("10 0/5 * * * ?"));
        }

        [Fact]
        public void TestBetweenWithInterval()
        {
            Assert.EqualsCaseInsensitive("Cada 3 minutos, del minuto 2 al 59 pasada la hora, a las 01:00 AM, 09:00 AM, y 10:00 PM, entre los días 11 y 26 del mes, de enero a junio", GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Fact]
        public void TestRecurringFirstOfMonth()
        {
            Assert.EqualsCaseInsensitive("A las 06:00 AM", GetDescription("0 0 6 1/1 * ?"));
        }

        [Fact]
        public void TestMinutesPastTheHour()
        {
            Assert.EqualsCaseInsensitive("A los 5 minutos de la hora", GetDescription("0 5 0/1 * * ?"));
        }

        [Fact]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.EqualsCaseInsensitive("Cada segundo, sólo en 2013", GetDescription("* * * * * * 2013"));
        }

        [Fact]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.EqualsCaseInsensitive("Cada minuto, sólo en 2013", GetDescription("* * * * * 2013"));
        }

        [Fact]
        public void TestTwoYearsOnly()
        {
            Assert.EqualsCaseInsensitive("Cada minuto, sólo en 2013 y 2014", GetDescription("* * * * * 2013,2014"));
        }

        [Fact]
        public void TestYearRange2()
        {
            Assert.EqualsCaseInsensitive("A las 12:23 PM, de enero a febrero, de 2013 a 2014", GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Fact]
        public void TestYearRange3()
        {
            Assert.EqualsCaseInsensitive("A las 12:23 PM, de enero a marzo, de 2013 a 2015", GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Fact]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
            Assert.EqualsCaseInsensitive("Cada 30 segundos, comenzando a los 5 segundos del minuto", GetDescription("5/30 * * * * ?"));
        }

        [Fact]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("Cada 30 minutos, comenzando a los 5 minutos de la hora", GetDescription("0 5/30 * * * ?"));
        }

        [Fact]
        public void TestHoursInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("Cada segundo, cada 8 horas, comenzando a las 05:00 AM", GetDescription("* * 5/8 * * ?"));
        }

        [Fact]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("A las 07:05 AM, cada 3 días, comenzando el día 2 del mes", GetDescription("0 5 7 2/3 * ? *"));
        }

        [Fact]
        public void TestMonthInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("A las 07:05 AM, cada 2 meses, de marzo a diciembre", GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Fact]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("A las 07:05 AM, cada 3 días de la semana, de martes a sábado", GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Fact]
        public void TestYearInternalWithStepValue()
        {
            Assert.EqualsCaseInsensitive("A las 07:05 AM, cada 4 años, de 2016 a 9999", GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}
