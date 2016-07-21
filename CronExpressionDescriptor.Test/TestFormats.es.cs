using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Threading;
using System.Globalization;

namespace CronExpressionDescriptor.Test
{
    [TestFixture]
    public class TestFormatsES
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            CultureInfo myCultureInfo =   new CultureInfo("es-ES");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [Test]
        public void TestEveryMinute()
        {           
            Assert.AreEqual("Cada minuto", ExpressionDescriptor.GetDescription("* * * * *"));
        }

        [Test]
        public void TestEvery1Minute()
        {
            Assert.AreEqual("Cada minuto", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("Cada minuto", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }
        
        [Test]
        public void TestEveryHour()
        {
            Assert.AreEqual("Cada hora", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("Cada hora", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }

        [Test]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("A las 11:00 PM, de lunes a viernes", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }

        [Test]
        public void TestEverySecond()
        {
            Assert.AreEqual("Cada segundo", ExpressionDescriptor.GetDescription("* * * * * *"));
        }

        [Test]
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("Cada 45 segundos", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }

        [Test]
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("Cada 5 minutos", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("Cada 10 minutos", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }

        [Test]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("Cada 5 minutos", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [Test]
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("A las 11:30 AM, de lunes a viernes", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [Test]
        public void TestDailyAtTime()
        {
            Assert.AreEqual("A las 11:30 AM", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }

        [Test]
        public void TestMinuteSpan()
        {
            Assert.AreEqual("Cada minuto entre las 11:00 AM y las 11:10 AM", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [Test]
        public void TestOneMonthOnly()
        {
            Assert.IsTrue(string.Equals("Cada minuto, sólo en marzo", ExpressionDescriptor.GetDescription("* * * 3 *"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestTwoMonthsOnly()
        {
            Assert.IsTrue(string.Equals("Cada minuto, sólo en marzo y junio", ExpressionDescriptor.GetDescription("* * * 3,6 *"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("A las 02:30 PM y 04:30 PM", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [Test]
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("A las 06:30 AM, 02:30 PM y 04:30 PM", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [Test]
        public void TestOnceAWeek()
        {
            Assert.AreEqual("A las 09:46 AM, sólo el lunes", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }

        [Test]
        public void TestDayOfMonth()
        {
            Assert.AreEqual("A las 12:23 PM, el día 15 del mes", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [Test]
        public void TestMonthName()
        {
            Assert.IsTrue(string.Equals("A las 12:23 PM, sólo en enero", ExpressionDescriptor.GetDescription("23 12 * JAN *"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }


        [Test]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.IsTrue(string.Equals("A las 12:23 PM, sólo en enero", ExpressionDescriptor.GetDescription("23 12 ? JAN *"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestMonthNameRange2()
        {
            Assert.IsTrue(string.Equals("A las 12:23 PM, de enero a febrero", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestMonthNameRange3()
        {
            Assert.IsTrue(string.Equals("A las 12:23 PM, de enero a marzo", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("A las 12:23 PM, sólo el domingo", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }

        [Test]
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("Cada 5 minutos, a las 03:00 PM, de lunes a viernes", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [Test]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("Cada minuto, en el tercer lunes del mes", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [Test]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("Cada minuto, en el último jueves del mes", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }

        [Test]
        public void TestLastDayOfTheMonth()
        {
            Assert.IsTrue(string.Equals("Cada 5 minutos, en el último día del mes, sólo en enero", ExpressionDescriptor.GetDescription("*/5 * L JAN *"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("Cada minuto, en el último día de la semana del mes", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [Test]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Cada minuto, en el último día de la semana del mes", ExpressionDescriptor.GetDescription("* * WL * *"));
        }

        [Test]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual("Cada minuto, en el primer día de la semana del mes", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [Test]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Cada minuto, en el primer día de la semana del mes", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [Test]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("Cada minuto, en el día de la semana más próximo al 5 del mes", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }

        [Test]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("Cada minuto, en el día de la semana más próximo al 5 del mes", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [Test]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("A las 02:02:30 PM", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [Test]
        public void TestSecondInternvals()
        {
            Assert.AreEqual("En los segundos 5 al 10 de cada minuto", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }

        [Test]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("En los segundos 5 al 10 de cada minuto, del minuto 30 al 35 pasada la hora, entre las 10:00 AM y las 12:59 PM", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Test]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("A los 30 segundos del minuto, cada 5 minutos", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [Test]
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("A los 30 minutos de la hora, entre las 10:00 AM y las 01:59 PM, sólo el miércoles y viernes", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }

        [Test]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("A los 10 segundos del minuto, cada 5 minutos", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }

        [Test]
        public void TestBetweenWithInterval()
        {
            Assert.IsTrue(string.Equals("Cada 3 minutos, del minuto 2 al 59 pasada la hora, a las 01:00 AM, 09:00 AM, y 10:00 PM, entre los días 11 y 26 del mes, de enero a junio", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("A las 06:00 AM", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }

        [Test]
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("A los 5 minutos de la hora", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }

        [Test]
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("Cada segundo, sólo en 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }

        [Test]
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("Cada minuto, sólo en 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [Test]
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual("Cada minuto, sólo en 2013 y 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [Test]
        public void TestYearRange2()
        {
            Assert.IsTrue(string.Equals("A las 12:23 PM, de enero a febrero, de 2013 a 2014", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestYearRange3()
        {
            Assert.IsTrue(string.Equals("A las 12:23 PM, de enero a marzo, de 2013 a 2015", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }

        [Test]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradyholt/cron-expression-descriptor/issues/49
            Assert.AreEqual("Cada 30 segundos, comenzando a los 5 segundos del minuto", ExpressionDescriptor.GetDescription("5/30 * * * * ?"));
        }

        [Test]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.AreEqual("Cada 30 minutos, comenzando a los 5 minutos de la hora", ExpressionDescriptor.GetDescription("0 5/30 * * * ?"));
        }
        
        [Test]
        public void TestHoursInternalWithStepValue()
        {
            Assert.AreEqual("Cada segundo, cada 8 horas, comenzando a las 05:00 AM", ExpressionDescriptor.GetDescription("* * 5/8 * * ?"));
        }
        
        [Test]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.AreEqual("A las 07:05 AM, cada 3 días, comenzando el día 2 del mes", ExpressionDescriptor.GetDescription("0 5 7 2/3 * ? *"));
        }
        
        [Test]
        public void TestMonthInternalWithStepValue()
        {
            Assert.IsTrue(string.Equals("A las 07:05 AM, cada 2 meses, de marzo a diciembre", ExpressionDescriptor.GetDescription("0 5 7 ? 3/2 ? *"),
                 Utilities.IsRunningOnMono() ? StringComparison.OrdinalIgnoreCase : StringComparison.CurrentCulture));
        }
        
        [Test]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.AreEqual("A las 07:05 AM, cada 3 días de la semana, de martes a sábado", ExpressionDescriptor.GetDescription("0 5 7 ? * 2/3 *"));
        }
                
        [Test]
        public void TestYearInternalWithStepValue()
        {
            Assert.AreEqual("A las 07:05 AM, cada 4 años, de 2016 a 9999", ExpressionDescriptor.GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}