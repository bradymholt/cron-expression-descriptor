using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Globalization;
using System.IO;

namespace CronExpressionDescriptor.Test
{
    [TestClass]
    public class TestFormatsPTBR
    {
        [TestInitialize]
        public void SetUp()
        {
            CultureInfo myCultureInfo =   new CultureInfo("pt-br");
            Thread.CurrentThread.CurrentCulture = myCultureInfo;
            Thread.CurrentThread.CurrentUICulture = myCultureInfo;
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll","pt-br")]
        public void TestEveryMinute()
        {           
            Assert.AreEqual("A cada minuto", ExpressionDescriptor.GetDescription("* * * * *"));
        }
        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestEvery1Minute()
        {
            Assert.AreEqual("A cada minuto", ExpressionDescriptor.GetDescription("*/1 * * * *"));
            Assert.AreEqual("A cada minuto", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
        }
        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestEveryHour()
        {
            Assert.AreEqual("A cada hora", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
            Assert.AreEqual("A cada hora", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
        }
        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            Assert.AreEqual("Às 11:00 PM, de segunda-feira a sexta-feira", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
        }
        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestEverySecond()
        {
            Assert.AreEqual("A cada segundo", ExpressionDescriptor.GetDescription("* * * * * *"));
        }
        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestEvery45Seconds()
        {
            Assert.AreEqual("A cada 45 segundos", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
        }
        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestEvery5Minutes()
        {
            Assert.AreEqual("A cada 05 minutos", ExpressionDescriptor.GetDescription("*/5 * * * *"));
            Assert.AreEqual("A cada 10 minutos", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
        }
        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestEvery5MinutesOnTheSecond()
        {
            Assert.AreEqual("A cada 05 minutos", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestWeekdaysAtTime()
        {
            Assert.AreEqual("Às 11:30 AM, de segunda-feira a sexta-feira", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestDailyAtTime()
        {
            Assert.AreEqual("Às 11:30 AM", ExpressionDescriptor.GetDescription("30 11 * * *"));
        }
        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestMinuteSpan()
        {
            Assert.AreEqual("A cada minuto entre 11:00 AM e 11:10 AM", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestOneMonthOnly()
        {
            Assert.AreEqual("A cada minuto, somente em março", ExpressionDescriptor.GetDescription("* * * 3 *"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestTwoMonthsOnly()
        {
            Assert.AreEqual("A cada minuto, somente em março e junho", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
        }
        [TestMethod]
        public void TestTwoTimesEachAfternoon()
        {
            Assert.AreEqual("Às 02:30 PM e 04:30 PM", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestThreeTimesDaily()
        {
            Assert.AreEqual("Às 06:30 AM, 02:30 PM e 04:30 PM", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestOnceAWeek()
        {
            Assert.AreEqual("Às 09:46 AM, somente de segunda-feira", ExpressionDescriptor.GetDescription("46 9 * * 1"));
        }
        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestDayOfMonth()
        {
            Assert.AreEqual("Às 12:23 PM, no dia 15 do mês", ExpressionDescriptor.GetDescription("23 12 15 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestMonthName()
        {
            Assert.AreEqual("Às 12:23 PM, somente em janeiro", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestDayOfMonthWithQuestionMark()
        {
            Assert.AreEqual("Às 12:23 PM, somente em janeiro", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
        }
        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestMonthNameRange2()
        {
            Assert.AreEqual("Às 12:23 PM, de janeiro a fevereiro", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestMonthNameRange3()
        {
            Assert.AreEqual("Às 12:23 PM, de janeiro a março", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestDayOfWeekName()
        {
            Assert.AreEqual("Às 12:23 PM, somente de domingo", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
        }
        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestDayOfWeekRange()
        {
            Assert.AreEqual("A cada 05 minutos, Às 03:00 PM, de segunda-feira a sexta-feira", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestDayOfWeekOnceInMonth()
        {
            Assert.AreEqual("A cada minuto, na terceira segunda-feira do mês", ExpressionDescriptor.GetDescription("* * * * MON#3"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            Assert.AreEqual("A cada minuto, na última quinta-feira do mês", ExpressionDescriptor.GetDescription("* * * * 4L"));
        }
        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestLastDayOfTheMonth()
        {
            Assert.AreEqual("A cada 05 minutos, no último dia do mês, somente em janeiro", ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestLastWeekdayOfTheMonth()
        {
            Assert.AreEqual("A cada minuto, no último dia da semana do mês", ExpressionDescriptor.GetDescription("* * LW * *"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestLastWeekdayOfTheMonth2()
        {
            Assert.AreEqual("A cada minuto, no último dia da semana do mês", ExpressionDescriptor.GetDescription("* * WL * *"));
        }
        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestFirstWeekdayOfTheMonth()
        {
            Assert.AreEqual("A cada minuto, no primeiro dia da semana do mês", ExpressionDescriptor.GetDescription("* * 1W * *"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestFirstWeekdayOfTheMonth2()
        {
            Assert.AreEqual("A cada minuto, no primeiro dia da semana do mês", ExpressionDescriptor.GetDescription("* * W1 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestParticularWeekdayOfTheMonth()
        {
            Assert.AreEqual("A cada minuto, no dia da semana mais próximo do dia 5 do mês", ExpressionDescriptor.GetDescription("* * 5W * *"));
        }
        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestParticularWeekdayOfTheMonth2()
        {
            Assert.AreEqual("A cada minuto, no dia da semana mais próximo do dia 5 do mês", ExpressionDescriptor.GetDescription("* * W5 * *"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestTimeOfDayWithSeconds()
        {
            Assert.AreEqual("Às 02:02:30 PM", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestSecondInternvals()
        {
            Assert.AreEqual("No segundo 05 até 10 de cada minuto", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
        }
        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestSecondMinutesHoursIntervals()
        {
            Assert.AreEqual("No segundo 05 até 10 de cada minuto, do minuto 30 até 35 de cada hora, entre 10:00 AM e 12:00 PM", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestEvery5MinutesAt30Seconds()
        {
            Assert.AreEqual("Aos 30 segundos do minuto, a cada 05 minutos", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
        }

        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestMinutesPastTheHourRange()
        {
            Assert.AreEqual("Aos 30 minutos da hora, entre 10:00 AM e 01:00 PM, somente de quarta-feira e sexta-feira", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
        }
        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestSecondsPastTheMinuteInterval()
        {
            Assert.AreEqual("Aos 10 segundos do minuto, a cada 05 minutos", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
        }
        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestBetweenWithInterval()
        {
            Assert.AreEqual("A cada 03 minutos, do minuto 02 até 59 de cada hora, Às 01:00 AM, 09:00 AM, e 10:00 PM, entre os dias 11 e 26 do mês, de janeiro a junho", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
        }
        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestRecurringFirstOfMonth()
        {
            Assert.AreEqual("Às 06:00 AM", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
        }
        [TestMethod]
        [DeploymentItem(@"pt-br\CronExpressionDescriptor.resources.dll", "pt-br")]
        public void TestMinutesPastTheHour()
        {
            Assert.AreEqual("Aos 05 minutos da hora", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
        }
    }
}