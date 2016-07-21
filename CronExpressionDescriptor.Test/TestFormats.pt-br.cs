using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Threading;
using System.Globalization;
using System.IO;

namespace CronExpressionDescriptor.Test
{
    [TestFixture]
    public class TestFormatsPTBR
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            CultureInfo myCultureInfo =   new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [Test]       
        public void TestEveryMinute()
        {           
            Assert.AreEqual("A cada minuto", ExpressionDescriptor.GetDescription("* * * * *"));
        }
        [Test]        
        public void TestEvery1Minute()
        {
            Assert.AreEqual("A cada minuto", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("A cada minuto", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }
        [Test]        
        public void TestEveryHour()
        {
            Assert.AreEqual("A cada hora", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("A cada hora", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }
        [Test]        
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("Às 11:00 PM, de segunda-feira a sexta-feira", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }
        [Test]        
        public void TestEverySecond()
        {
            Assert.AreEqual("A cada segundo", ExpressionDescriptor.GetDescription("* * * * * *"));
        }
        [Test]        
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("A cada 45 segundos", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }
        [Test]        
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("A cada 5 minutos", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("A cada 10 minutos", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }
        [Test]        
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("A cada 5 minutos", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [Test]        
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("Às 11:30 AM, de segunda-feira a sexta-feira", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [Test]        
        public void TestDailyAtTime()
        {
            Assert.AreEqual("Às 11:30 AM", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }
        [Test]        
        public void TestMinuteSpan()
        {
            Assert.AreEqual("A cada minuto entre 11:00 AM e 11:10 AM", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [Test]        
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("A cada minuto, somente em março", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [Test]        
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("A cada minuto, somente em março e junho", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }
        [Test]        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("Às 02:30 PM e 04:30 PM", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [Test]        
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("Às 06:30 AM, 02:30 PM e 04:30 PM", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [Test]        
        public void TestOnceAWeek()
        {
            Assert.AreEqual("Às 09:46 AM, somente de segunda-feira", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }
        [Test]        
        public void TestDayOfMonth()
        {
            Assert.AreEqual("Às 12:23 PM, no dia 15 do mês", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [Test]        
        public void TestMonthName()
        {
            Assert.AreEqual("Às 12:23 PM, somente em janeiro", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
        }

        [Test]        
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("Às 12:23 PM, somente em janeiro", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
        }
        [Test]        
        public void TestMonthNameRange2()
        {
            Assert.AreEqual("Às 12:23 PM, de janeiro a fevereiro", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
        }

        [Test]        
        public void TestMonthNameRange3()
        {
            Assert.AreEqual("Às 12:23 PM, de janeiro a março", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
        }

        [Test]        
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("Às 12:23 PM, somente de domingo", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }
        [Test]        
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("A cada 5 minutos, Às 03:00 PM, de segunda-feira a sexta-feira", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [Test]        
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("A cada minuto, na terceira segunda-feira do mês", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [Test]        
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("A cada minuto, na última quinta-feira do mês", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }
        [Test]        
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual("A cada 5 minutos, no último dia do mês, somente em janeiro", ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [Test]        
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("A cada minuto, no último dia da semana do mês", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [Test]        
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("A cada minuto, no último dia da semana do mês", ExpressionDescriptor.GetDescription("* * WL * *"));
        }
        [Test]        
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual("A cada minuto, no primeiro dia da semana do mês", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [Test]        
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("A cada minuto, no primeiro dia da semana do mês", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [Test]        
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("A cada minuto, no dia da semana mais próximo do dia 5 do mês", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }
        [Test]        
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("A cada minuto, no dia da semana mais próximo do dia 5 do mês", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [Test]        
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("Às 02:02:30 PM", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [Test]        
        public void TestSecondInternvals()
        {
            Assert.AreEqual("No segundo 5 até 10 de cada minuto", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }
        [Test]        
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("No segundo 5 até 10 de cada minuto, do minuto 30 até 35 de cada hora, entre 10:00 AM e 12:59 PM", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [Test]        
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("Aos 30 segundos do minuto, a cada 5 minutos", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [Test]        
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("Aos 30 minutos da hora, entre 10:00 AM e 01:59 PM, somente de quarta-feira e sexta-feira", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }
        [Test]        
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("Aos 10 segundos do minuto, a cada 5 minutos", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }
        [Test]        
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual("A cada 3 minutos, do minuto 2 até 59 de cada hora, Às 01:00 AM, 09:00 AM, e 10:00 PM, entre os dias 11 e 26 do mês, de janeiro a junho", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }
        [Test]        
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("Às 06:00 AM", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }
        [Test]        
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("Aos 5 minutos da hora", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }
        [Test]        
        public void TestOneYearOnlyWithSeconds()
        {
            Assert.AreEqual("A cada segundo, somente em 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
        }

        [Test]        
        public void TestOneYearOnlyWithoutSeconds()
        {
            Assert.AreEqual("A cada minuto, somente em 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
        }

        [Test]        
        public void TestTwoYearsOnly()
        {
            Assert.AreEqual("A cada minuto, somente em 2013 e 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
        }

        [Test]        
        public void TestYearRange2()
        {
            Assert.AreEqual("Às 12:23 PM, de janeiro a fevereiro, de 2013 a 2014", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
        }

        [Test]        
        public void TestYearRange3()
        {
            Assert.AreEqual("Às 12:23 PM, de janeiro a março, de 2013 a 2015", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
        }

        [Test]
        public void TestSecondsInternalWithStepValue()
        {
            // GitHub Issue #49: https://github.com/bradyholt/cron-expression-descriptor/issues/49
            Assert.AreEqual("A cada 30 segundos, iniciando aos 5 segundos do minuto", ExpressionDescriptor.GetDescription("5/30 * * * * ?"));
        }

        [Test]
        public void TestMinutesInternalWithStepValue()
        {
            Assert.AreEqual("A cada 30 minutos, iniciando aos 5 minutos da hora", ExpressionDescriptor.GetDescription("0 5/30 * * * ?"));
        }
        
        [Test]
        public void TestHoursInternalWithStepValue()
        {
            Assert.AreEqual("A cada segundo, a cada 8 horas, iniciando Às 05:00 AM", ExpressionDescriptor.GetDescription("* * 5/8 * * ?"));
        }
        
        [Test]
        public void TestDayOfMonthInternalWithStepValue()
        {
            Assert.AreEqual("Às 07:05 AM, a cada 3 dias, iniciando no dia 2 do mês", ExpressionDescriptor.GetDescription("0 5 7 2/3 * ? *"));
        }
        
        [Test]
        public void TestMonthInternalWithStepValue()
        {
            Assert.AreEqual("Às 07:05 AM, a cada 2 meses, de março a dezembro", ExpressionDescriptor.GetDescription("0 5 7 ? 3/2 ? *"));
        }
        
        [Test]
        public void TestDayOfWeekInternalWithStepValue()
        {
            Assert.AreEqual("Às 07:05 AM, a cada 3 dias de semana, de terça-feira a sábado", ExpressionDescriptor.GetDescription("0 5 7 ? * 2/3 *"));
        }
                
        [Test]
        public void TestYearInternalWithStepValue()
        {
            Assert.AreEqual("Às 07:05 AM, a cada 4 anos, de 2016 a 9999", ExpressionDescriptor.GetDescription("0 5 7 ? * ? 2016/4"));
        }
    }
}