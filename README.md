# cron-expression-descriptor
A C# library that converts cron expressions into human readable strings.  
Author: Brady Holt (http://www.geekytidbits.com)  
License: MIT

**Download**

If you want to get up and running quickly and just want the library, [visit the Downloads page](https://github.com/bradyholt/cron-expression-descriptor/downloads) and download the latest CronExpressionDescriptor.dll library assembly.

**Usage Examples (as Unit Tests)**  

        [TestMethod]
        public void TestEveryMinute()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("* * * * *");
            Assert.AreEqual("Every minute", ceh.GetDescription());
        }

        [TestMethod]
        public void TestEvery1Minute()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("*/1 * * * *");
            Assert.AreEqual("Every 1 minute", ceh.GetDescription());

            ceh = new ExpressionDescriptor("0 0/1 * * * ?");
            Assert.AreEqual("Every 1 minute", ceh.GetDescription());
        }

        [TestMethod]
        public void TestTimeOfDayCertainDaysOfWeek()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("0 23 ? * MON-FRI");
            Assert.AreEqual("At 11:00 PM, Monday through Friday", ceh.GetDescription());
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
            Assert.AreEqual("At 11:30 AM, Monday through Friday", ceh.GetDescription());
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
            Assert.AreEqual("At 09:46 AM, only on Monday", ceh.GetDescription());
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
            Assert.AreEqual("At 12:23 PM, January through February", ceh.GetDescription());
        }

        [TestMethod]
        public void TestMonthNameRange3()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("23 12 * JAN-MAR *");
            Assert.AreEqual("At 12:23 PM, January through March", ceh.GetDescription());
        }

        [TestMethod]
        public void TestDayOfWeekName()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("23 12 * * SUN");
            Assert.AreEqual("At 12:23 PM, only on Sunday", ceh.GetDescription());
        }

        [TestMethod]
        public void TestDayOfWeekRange()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("*/5 15 * * MON-FRI");
            Assert.AreEqual("Every 5 minutes, at 03:00 PM, Monday through Friday", ceh.GetDescription());
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
            Assert.AreEqual("Seconds 05 through 10 past the minute", ceh.GetDescription());
        }

        [TestMethod]
        public void TestSecondMinutesHoursIntervals()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("5-10 30-35 10-12 * * *");
            Assert.AreEqual("Seconds 05 through 10 past the minute, between 30 and 35 minutes past the hour, during hours 10:00 AM and 12:00 PM", ceh.GetDescription());
        }

        [TestMethod]
        public void TestEvery5MinutesAt30Seconds()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("30 */5 * * * *");
            Assert.AreEqual("At 30 seconds past the minute, every 5 minutes", ceh.GetDescription());
        }

        [TestMethod]
        public void TestMinutesPastTheHourRange()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("0 30 10-13 ? * WED,FRI");
            Assert.AreEqual("At 30 minutes past the hour, during hours 10:00 AM and 01:00 PM, only on Wednesday and Friday", ceh.GetDescription());
        }

        [TestMethod]
        public void TestSecondsPastTheMinuteInterval()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("10 0/5 * * * ?");
            Assert.AreEqual("At 10 seconds past the minute, every 5 minutes", ceh.GetDescription());
        }

        [TestMethod]
        public void TestBetweenWithInternval()
        {
            ExpressionDescriptor ceh = new ExpressionDescriptor("2-59/3 1,9,22 11-26 1-6 ?");
            Assert.AreEqual("Every 3 minutes, between 02 and 59 minutes past the hour, during 01:00 AM, 09:00 AM, and 10:00 PM, between day 11 and 26 of the month, January through June", ceh.GetDescription());
        }
        
**Notes**          

 * Supports 5 or 6 (w/ seconds) part cron expressions.
 * Does NOT support Year in cron expression.