# cron-expression-descriptor
A C# library that converts cron expressions into human readable strings.  
Author: Brady Holt (http://www.geekytidbits.com)  
License: MIT

**Usage Examples (as Unit Tests)**  

	[TestMethod]
        public void TestEveryMinute()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * *");
            Assert.AreEqual("Every minute", ceh.GetDescription());
        }

        [TestMethod]
        public void TestEverySecond()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * * *");
            Assert.AreEqual("Every second", ceh.GetDescription());
        }

        [TestMethod]
        public void TestEvery45Seconds()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("*/45 * * * * *");
            Assert.AreEqual("Every 45 seconds", ceh.GetDescription());
        }

        [TestMethod]
        public void TestEvery5Minutes()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("*/5 * * * *");
            Assert.AreEqual("Every 5 minutes", ceh.GetDescription());
        }

        [TestMethod]
        public void TestEvery5MinutesOnTheSecond()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("0 */5 * * * *");
            Assert.AreEqual("Every 5 minutes", ceh.GetDescription());
        }

        [TestMethod]
        public void TestWeekdaysAtTime()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 11 * * 1-5");
            Assert.AreEqual("At 11:30 AM, Monday-Friday", ceh.GetDescription());
        }

        [TestMethod]
        public void TestDailyAtTime()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 11 * * *");
            Assert.AreEqual("At 11:30 AM", ceh.GetDescription());
        }

        [TestMethod]
        public void TestMinuteSpan()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("0-10 11 * * *");
            Assert.AreEqual("Every minute between 11:00 AM and 11:10 AM", ceh.GetDescription());
        }

        [TestMethod]
        public void TestOneMonthOnly()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * 3 *");
            Assert.AreEqual("Every minute, only in March", ceh.GetDescription());
        }

        [TestMethod]
        public void TestTwoMonthsOnly()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * 3,6 *");
            Assert.AreEqual("Every minute, only in March and June", ceh.GetDescription());
        }

        [TestMethod]
        public void TestTwoTimesEachAfternoon()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 14,16 * * *");
            Assert.AreEqual("At 02:30 PM and 04:30 PM", ceh.GetDescription());
        }

        [TestMethod]
        public void TestThreeTimesDaily()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 6,14,16 * * *");
            Assert.AreEqual("At 06:30 AM, 02:30 PM, and 04:30 PM", ceh.GetDescription());
        }

        [TestMethod]
        public void TestOnceAWeek()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("46 9 * * 1");
            Assert.AreEqual("At 09:46 AM, only on Mondays", ceh.GetDescription());
        }

        [TestMethod]
        public void TestDayOfMonth()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("23 12 15 * *");
            Assert.AreEqual("At 12:23 PM, on day 15 of the month", ceh.GetDescription());
        }

        [TestMethod]
        public void TestMonthName()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("23 12 * JAN *");
            Assert.AreEqual("At 12:23 PM, only in January", ceh.GetDescription());
        }

        [TestMethod]
        public void TestDayOfMonthWithQuestionMark()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("23 12 ? JAN *");
            Assert.AreEqual("At 12:23 PM, only in January", ceh.GetDescription());
        }

        [TestMethod]
        public void TestMonthNameRange2()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("23 12 * JAN-FEB *");
            Assert.AreEqual("At 12:23 PM, January-February", ceh.GetDescription());
        }

        [TestMethod]
        public void TestMonthNameRange3()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("23 12 * JAN-MAR *");
            Assert.AreEqual("At 12:23 PM, January-March", ceh.GetDescription());
        }

        [TestMethod]
        public void TestDayOfWeekName()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("23 12 * * SUN");
            Assert.AreEqual("At 12:23 PM, only on Sundays", ceh.GetDescription());
        }

        [TestMethod]
        public void TestDayOfWeekRange()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("*/5 15 * * MON-FRI");
            Assert.AreEqual("Every 5 minutes, at 03:00 PM, Monday-Friday", ceh.GetDescription());
        }

        [TestMethod]
        public void TestDayOfWeekOnceInMonth()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * MON#3");
            Assert.AreEqual("Every minute, on the third Monday of the month", ceh.GetDescription());
        }

        [TestMethod]
        public void TestLastDayOfTheWeekOfTheMonth()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * 4L");
            Assert.AreEqual("Every minute, on the last Thursday of the month", ceh.GetDescription());
        }

        [TestMethod]
        public void TestLastDayOfTheMonth()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("*/5 * L JAN *");
            Assert.AreEqual("Every 5 minutes, on the last day of the month, only in January", ceh.GetDescription());
        }

        [TestMethod]
        public void TestTimeOfDayWithSeconds()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 02 14 * * *");
            Assert.AreEqual("At 02:02:30 PM", ceh.GetDescription());
        }

        [TestMethod]
        public void TestSecondInternvals()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("5-10 * * * * *");
            Assert.AreEqual("Every second between :05 and :10", ceh.GetDescription());
        }

        [TestMethod]
        public void TestSecondMinutesHoursIntervals()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("5-10 30-35 10-12 * * *");
            Assert.AreEqual("Every second between :05 and :10, between the minutes of :30 and :35, between the hours of 10:00 AM and 12:00 PM", ceh.GetDescription());
        }

        [TestMethod]
        public void TestEvery5MinutesAt30Seconds()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 */5 * * * *");
            Assert.AreEqual("At seconds :30, every 5 minutes", ceh.GetDescription());
        }
        