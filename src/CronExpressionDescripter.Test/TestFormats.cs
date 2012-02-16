using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CronExpressionDescripter;

namespace CronExpressionDescripter.Test
{
    [TestClass]
    public class TestFormats
    {
        [TestMethod]
        public void TestEveryMinute()
        {
            ExpressionDescripter ceh = new ExpressionDescripter("* * * * *");
            Assert.AreEqual("Every minute, daily", ceh.GetHumanDescription());
        }

        [TestMethod]
        public void TestEvery5Minutes()
        {
            ExpressionDescripter ceh = new ExpressionDescripter("*/5 * * * *");
            Assert.AreEqual("Every 5 minutes, daily", ceh.GetHumanDescription());
        }

        [TestMethod]
        public void TestWeekdaysAtTime()
        {
            ExpressionDescripter ceh = new ExpressionDescripter("30 11 * * 1-5");
            Assert.AreEqual("At 11:30 AM, Monday-Friday", ceh.GetHumanDescription());
        }

        [TestMethod]
        public void TestDailyAtTime()
        {
            ExpressionDescripter ceh = new ExpressionDescripter("30 11 * * *");
            Assert.AreEqual("At 11:30 AM, daily", ceh.GetHumanDescription());
        }

        [TestMethod]
        public void TestMinuteSpan()
        {
            ExpressionDescripter ceh = new ExpressionDescripter("0-10 11 * * *");
            Assert.AreEqual("Every minute between 11:00 AM and 11:10 AM, daily", ceh.GetHumanDescription());
        }

        [TestMethod]
        public void TestOneMonthOnly()
        {
            ExpressionDescripter ceh = new ExpressionDescripter("* * * 3 *");
            Assert.AreEqual("Every minute, daily, only in March", ceh.GetHumanDescription());
        }

        [TestMethod]
        public void TestTwoMonthsOnly()
        {
            ExpressionDescripter ceh = new ExpressionDescripter("* * * 3,6 *");
            Assert.AreEqual("Every minute, daily, only in March and June", ceh.GetHumanDescription());
        }

        [TestMethod]
        public void TestTwoTimesEachAfternoon()
        {
            ExpressionDescripter ceh = new ExpressionDescripter("30 14,16 * * *");
            Assert.AreEqual("At 02:30 PM and 04:30 PM, daily", ceh.GetHumanDescription());
        }

        [TestMethod]
        public void TestThreeTimesDaily()
        {
            ExpressionDescripter ceh = new ExpressionDescripter("30 6,14,16 * * *");
            Assert.AreEqual("At 06:30 AM, 02:30 PM, and 04:30 PM, daily", ceh.GetHumanDescription());
        }

        [TestMethod]
        public void TestOnceAWeek()
        {
            ExpressionDescripter ceh = new ExpressionDescripter("46 9 * * 1");
            Assert.AreEqual("At 09:46 AM, only on Mondays", ceh.GetHumanDescription());
        }

        [TestMethod]
        public void TestDayOfMonth()
        {
            ExpressionDescripter ceh = new ExpressionDescripter("23 12 15 * *");
            Assert.AreEqual("At 12:23 PM, on day 15 of the month", ceh.GetHumanDescription());
        }
    }
}