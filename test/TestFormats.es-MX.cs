using System;
using Xunit;
using Assert = CronExpressionDescriptor.Test.Support.AssertExtensions;

namespace CronExpressionDescriptor.Test
{
    /// <summary>
    /// Tests for Spanish (Mexico) translation
    /// </summary>
    public class TestFormatsESMX : Support.BaseTestFormats
    {
        protected override string GetLocale()
        {
            return "es-MX";
        }

        [Fact]
        public void TestEveryMinute()
        {
            Assert.ContainsCaseInsensitive("Cada un minuto", GetDescription("* * * * *"));
        }

        [Fact]
        public void TestEvery1Minute()
        {
            Assert.ContainsCaseInsensitive("Cada un minuto", GetDescription("*/1 * * * *"));
            Assert.ContainsCaseInsensitive("Cada un minuto", GetDescription("0 0/1 * * * ?"));
        }

        [Fact]
        public void TestEveryHour()
        {
            Assert.ContainsCaseInsensitive("Cada una hora", GetDescription("0 0 * * * ?"));
            Assert.ContainsCaseInsensitive("Cada una hora", GetDescription("0 0 0/1 * * ?"));
        }

        [Fact]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.ContainsCaseInsensitive("A las 11:00 P. M., lunes hasta viernes", GetDescription("0 23 ? * MON-FRI"));
        }

        [Fact]
        public void TestEverySecond()
        {
            Assert.ContainsCaseInsensitive("Cada un segundo", GetDescription("* * * * * *"));
        }

        [Fact]
        public void TestEvery45Seconds()
        {
            Assert.ContainsCaseInsensitive("Cada 45 segundos", GetDescription("*/45 * * * * *"));
        }

        [Fact]
        public void TestEvery5Minutes()
        {
            Assert.ContainsCaseInsensitive("Cada 5 minutos", GetDescription("*/5 * * * *"));
            Assert.ContainsCaseInsensitive("Cada 10 minutos", GetDescription("0 0/10 * * * ?"));
        }

        [Fact]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.ContainsCaseInsensitive("Cada 5 minutos", GetDescription("0 */5 * * * *"));
        }

        [Fact]
        public void TestWeekdaysAtTime()
        {
            Assert.ContainsCaseInsensitive("A las 11:30 A. M., lunes hasta viernes", GetDescription("30 11 * * 1-5"));
        }

        [Fact]
        public void TestDailyAtTime()
        {
            Assert.ContainsCaseInsensitive("A las 11:30 A. M.", GetDescription("30 11 * * *"));
        }

        [Fact]
        public void TestMinuteSpan()
        {
            Assert.ContainsCaseInsensitive("Cada un minuto entre las 11:00 A. M. y las 11:10 A. M.", GetDescription("0-10 11 * * *"));
        }

        [Fact]
        public void TestOneMonthOnly()
        {
            Assert.ContainsCaseInsensitive("Cada un minuto, solo en marzo", GetDescription("* * * 3 *"));
        }

        [Fact]
        public void TestTwoMonthsOnly()
        {
            Assert.ContainsCaseInsensitive("Cada un minuto, solo en marzo y junio", GetDescription("* * * 3,6 *"));
        }

        [Fact]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.ContainsCaseInsensitive("A las 02:30 P. M. y 04:30 P. M.", GetDescription("30 14,16 * * *"));
        }

        [Fact]
        public void TestThreeTimesDaily()
        {
            Assert.ContainsCaseInsensitive("A las 06:30 A. M., 02:30 P. M. y 04:30 P. M.", GetDescription("30 6,14,16 * * *"));
        }

        [Fact]
        public void TestOnceAWeek()
        {
            Assert.ContainsCaseInsensitive("A las 09:46 A. M., solo el lunes", GetDescription("46 9 * * 1"));
        }

        [Fact]
        public void TestDayOfMonth()
        {
            Assert.ContainsCaseInsensitive("A las 12:23 P. M., el día 15 del mes", GetDescription("23 12 15 * *"));
        }

        [Fact]
        public void TestMonthName()
        {
            Assert.ContainsCaseInsensitive("A las 12:23 P. M., solo en enero", GetDescription("23 12 * JAN *"));
        }


        [Fact]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.ContainsCaseInsensitive("A las 12:23 P. M., solo en enero", GetDescription("23 12 ? JAN *"));
        }

        [Fact]
        public void TestMonthNameRange2()
        {
            Assert.ContainsCaseInsensitive("A las 12:23 P. M., enero hasta febrero", GetDescription("23 12 * JAN-FEB *"));
        }

        [Fact]
        public void TestMonthNameRange3()
        {
            Assert.ContainsCaseInsensitive("A las 12:23 P. M., enero hasta marzo", GetDescription("23 12 * JAN-MAR *"));
        }

        [Fact]
        public void TestDayOfWeekName()
        {
            Assert.ContainsCaseInsensitive("A las 12:23 P. M., solo el domingo", GetDescription("23 12 * * SUN"));
        }

        [Fact]
        public void TestDayOfWeekRange()
        {
            Assert.ContainsCaseInsensitive("Cada 5 minutos, entre 03:00 P. M. y 03:59 P. M., lunes hasta viernes", GetDescription("*/5 15 * * MON-FRI"));
        }

        [Fact]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.ContainsCaseInsensitive("Cada un minuto, el tercero lunes del mes", GetDescription("* * * * MON#3"));
        }

        [Fact]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.ContainsCaseInsensitive("Cada un minuto, el último jueves del mes", GetDescription("* * * * 4L"));
        }

        [Fact]
        public void TestLastDayOfTheMonth()
        {
            Assert.ContainsCaseInsensitive("Cada 5 minutos, el último día del mes, solo en enero", GetDescription("*/5 * L JAN *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.ContainsCaseInsensitive("Cada un minuto, el último día hábil del mes", GetDescription("* * LW * *"));
        }

        [Fact]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.ContainsCaseInsensitive("Cada un minuto, el último día hábil del mes", GetDescription("* * WL * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.ContainsCaseInsensitive("Cada un minuto, el primer día hábil del mes", GetDescription("* * 1W * *"));
        }

        [Fact]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.ContainsCaseInsensitive("Cada un minuto, el primer día hábil del mes", GetDescription("* * W1 * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.ContainsCaseInsensitive("Cada un minuto, el el día más próximo al día hábil 5 del mes", GetDescription("* * 5W * *"));
        }

        [Fact]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.ContainsCaseInsensitive("Cada un minuto, el el día más próximo al día hábil 5 del mes", GetDescription("* * W5 * *"));
        }

        [Fact]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.ContainsCaseInsensitive("A las 02:02:30 P. M.", GetDescription("30 02 14 * * *"));
        }

        [Fact]
        public void TestSecondInternvals()
        {
            Assert.ContainsCaseInsensitive("Segundos 5 hasta 10 después del minuto", GetDescription("5-10 * * * * *"));
        }

        [Fact]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.ContainsCaseInsensitive("Segundos 5 hasta 10 después del minuto, minutos 30 hasta 35 después de la hora, entre 10:00 A. M. y 12:59 P. M.", GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Fact]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.ContainsCaseInsensitive("A 30 segundos después del minuto, cada 5 minutos", GetDescription("30 */5 * * * *"));
        }

        [Fact]
        public void TestMinutesPastTheHourRange()
        {
            Assert.ContainsCaseInsensitive("A 30 minutos después de la hora, entre 10:00 A. M. y 01:59 P. M., solo el miércoles y viernes", GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Fact]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.ContainsCaseInsensitive("A 10 segundos después del minuto, cada 5 minutos", GetDescription("10 0/5 * * * ?"));
        }

        [Fact]
        public void TestBetweenWithInterval()
        {
            Assert.ContainsCaseInsensitive("Cada 3 minutos, minutos 2 hasta 59 después de la hora, a 01:00 A. M., 09:00 A. M., y 10:00 P. M., entre el 11 y el 26 día del mes, enero hasta junio", GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }

        [Fact]
        public void TestRecurringFirstOfMonth()
        {
            Assert.ContainsCaseInsensitive("A las 06:00 A. M.", GetDescription("0 0 6 1/1 * ?"));
        }

        [Fact]
        public void TestMinutesPastTheHour()
        {
            Assert.ContainsCaseInsensitive("A 5 minutos después de la hora", GetDescription("0 5 0/1 * * ?"));
        }

        [Fact]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.ContainsCaseInsensitive("Cada un segundo, solo en 2013", GetDescription("* * * * * * 2013"));
        }

        [Fact]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.ContainsCaseInsensitive("Cada un minuto, solo en 2013", GetDescription("* * * * * 2013"));
        }

        [Fact]
        public void TestTwoYearsOnly()
        {
            Assert.ContainsCaseInsensitive("Cada un minuto, solo en 2013 y 2014", GetDescription("* * * * * 2013,2014"));
        }

        [Fact]
        public void TestYearRange2()
        {
            Assert.ContainsCaseInsensitive("A las 12:23 P. M., enero hasta febrero, 2013 hasta 2014", GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Fact]
        public void TestYearRange3()
        {
            Assert.ContainsCaseInsensitive("A las 12:23 P. M., enero hasta marzo, 2013 hasta 2015", GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Fact]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradymholt/cron-expression-descriptor/issues/49
            Assert.ContainsCaseInsensitive("Cada 30 segundos, a partir de a 5 segundos después del minuto", GetDescription("5/30 * * * * ?"));
        }

        [Fact]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.ContainsCaseInsensitive("Cada 30 minutos, a partir de a 5 minutos después de la hora", GetDescription("0 5/30 * * * ?"));
        }

        [Fact]
        public void TestHoursInternalWithStepValue()
        {
            Assert.ContainsCaseInsensitive("Cada un segundo, cada 8 horas, a partir de a 05:00 A. M.", GetDescription("* * 5/8 * * ?"));
        }

        [Fact]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.ContainsCaseInsensitive("A las 07:05 A. M., cada 3 días, a partir de el día 2 del mes", GetDescription("0 5 7 2/3 * ? *"));
        }

        [Fact]
        public void TestMonthInternalWithStepValue()
        {
            Assert.ContainsCaseInsensitive("A las 07:05 A. M., cada 2 meses, marzo hasta diciembre", GetDescription("0 5 7 ? 3/2 ? *"));
        }

        [Fact]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.ContainsCaseInsensitive("A las 07:05 A. M., cada 3 días de la semana, martes hasta sábado", GetDescription("0 5 7 ? * 2/3 *"));
        }

        [Fact]
        public void TestYearInternalWithStepValue()
        {
            Assert.ContainsCaseInsensitive("A las 07:05 A. M., cada 4 años, 2016 hasta 9999", GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}
