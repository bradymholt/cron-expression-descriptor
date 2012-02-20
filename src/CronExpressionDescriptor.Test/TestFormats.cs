using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CronExpressionDescriptor;

namespace CronExpressionDescriptor.Test
{
    [TestClass]
    public class TestFormats
    {
        [TestMethod]
        public void TestEveryMinute()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * *");
            Assert.AreEqual("Every minute, daily", ceh.FullDescription);
        }

        [TestMethod]
        public void TestEvery5Minutes()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("*/5 * * * *");
            Assert.AreEqual("Every 5 minutes, daily", ceh.FullDescription);
        }

        [TestMethod]
        public void TestWeekdaysAtTime()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 11 * * 1-5");
            Assert.AreEqual("At 11:30 AM, Monday-Friday", ceh.FullDescription);
        }

        [TestMethod]
        public void TestDailyAtTime()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 11 * * *");
            Assert.AreEqual("At 11:30 AM, daily", ceh.FullDescription);
        }

        [TestMethod]
        public void TestMinuteSpan()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("0-10 11 * * *");
            Assert.AreEqual("Every minute between 11:00 AM and 11:10 AM, daily", ceh.FullDescription);
        }

        [TestMethod]
        public void TestOneMonthOnly()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * 3 *");
            Assert.AreEqual("Every minute, daily, only in March", ceh.FullDescription);
        }

        [TestMethod]
        public void TestTwoMonthsOnly()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * 3,6 *");
            Assert.AreEqual("Every minute, daily, only in March and June", ceh.FullDescription);
        }

        [TestMethod]
        public void TestTwoTimesEachAfternoon()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 14,16 * * *");
            Assert.AreEqual("At 02:30 PM and 04:30 PM, daily", ceh.FullDescription);
        }

        [TestMethod]
        public void TestThreeTimesDaily()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 6,14,16 * * *");
            Assert.AreEqual("At 06:30 AM, 02:30 PM, and 04:30 PM, daily", ceh.FullDescription);
        }

        [TestMethod]
        public void TestOnceAWeek()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("46 9 * * 1");
            Assert.AreEqual("At 09:46 AM, only on Mondays", ceh.FullDescription);
        }

        [TestMethod]
        public void TestDayOfMonth()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("23 12 15 * *");
            Assert.AreEqual("At 12:23 PM, on day 15 of the month", ceh.FullDescription);
        }

        [TestMethod]
        public void TestMonthName()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("23 12 * JAN *");
            Assert.AreEqual("At 12:23 PM, daily, only in January", ceh.FullDescription);
        }

        [TestMethod]
        public void TestMonthNameRange2()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("23 12 * JAN-FEB *");
            Assert.AreEqual("At 12:23 PM, daily, January-February", ceh.FullDescription);
        }

        [TestMethod]
        public void TestMonthNameRange3()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("23 12 * JAN-MAR *");
            Assert.AreEqual("At 12:23 PM, daily, January-March", ceh.FullDescription);
        }

        [TestMethod]
        public void TestDayOfWeekName()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("23 12 * * SUN");
            Assert.AreEqual("At 12:23 PM, only on Sundays", ceh.FullDescription);
        }

        [TestMethod]
        public void TestDayOfWeekRange()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("*/5 15 * * MON-FRI");
            Assert.AreEqual("Every 5 minutes, at 03:00 PM, Monday-Friday", ceh.FullDescription);
        }
    }
}