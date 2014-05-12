Cron Expression Descriptor
==========================
A .NET library that converts cron expressions into human readable strings

**Author**: Brady Holt (http://www.geekytidbits.com)  
**Contributors**: Renato Lima, Ivan Santos, Fabien Brooke, Siarhei Khalipski, Mustafa SADEDİL  
**License**: [MIT](http://opensource.org/licenses/MIT)

Features         
--------
 * Supports all cron expression special characters including * / , - ? L W, #
 * Supports 5, 6 (w/ seconds or year), or 7 (w/ seconds and year) part cron expressions
 * Provides casing options (Sentence, Title, Lower, etc.)
 * Localization with support for 5 languages
 
Languages Available
--------

 * English ([Brady Holt](https://github.com/bradyholt))
 * Brazilian ([Renato Lima](https://github.com/natenho))
 * Spanish ([Ivan Santos](https://github.com/ivansg))
 * Norwegian ([Siarhei Khalipski](https://github.com/KhalipskiSiarhei))
 * Turkish ([Mustafa SADEDİL](https://github.com/sadedil))
 * Dutch ([TotalMace](https://github.com/TotalMace))
 * Chinese Simplified ([Star Peng](https://github.com/starpeng))

Download
----------

Cron Expression Descriptor releases can be installed with **NuGet**.  [Visit the NuGet Package page](https://www.nuget.org/packages/CronExpressionDescriptor/) for more info.

View [Releases](https://github.com/bradyholt/cron-expression-descriptor/releases) for release version history.

Usage Examples (as Unit Tests)
--------

    Assert.AreEqual("Every minute", ExpressionDescriptor.GetDescription("* * * * *"));
    Assert.AreEqual("Every minute", ExpressionDescriptor.GetDescription("*/1 * * * *"));
    Assert.AreEqual("Every minute", ExpressionDescriptor.GetDescription("0 0/1 * * * ?"));
    Assert.AreEqual("Every hour", ExpressionDescriptor.GetDescription("0 0 * * * ?"));
    Assert.AreEqual("Every hour", ExpressionDescriptor.GetDescription("0 0 0/1 * * ?"));
    Assert.AreEqual("At 11:00 PM, Monday through Friday", ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI"));
    Assert.AreEqual("Every second", ExpressionDescriptor.GetDescription("* * * * * *"));
    Assert.AreEqual("Every 45 seconds", ExpressionDescriptor.GetDescription("*/45 * * * * *"));
    Assert.AreEqual("Every 05 minutes", ExpressionDescriptor.GetDescription("*/5 * * * *"));
    Assert.AreEqual("Every 10 minutes", ExpressionDescriptor.GetDescription("0 0/10 * * * ?"));
    Assert.AreEqual("Every 05 minutes", ExpressionDescriptor.GetDescription("0 */5 * * * *"));
    Assert.AreEqual("At 11:30 AM, Monday through Friday", ExpressionDescriptor.GetDescription("30 11 * * 1-5"));
    Assert.AreEqual("At 11:30 AM", ExpressionDescriptor.GetDescription("30 11 * * *"));
    Assert.AreEqual("Every minute between 11:00 AM and 11:10 AM", ExpressionDescriptor.GetDescription("0-10 11 * * *"));
    Assert.AreEqual("Every minute, only in March", ExpressionDescriptor.GetDescription("* * * 3 *"));
    Assert.AreEqual("Every minute, only in March and June", ExpressionDescriptor.GetDescription("* * * 3,6 *"));
    Assert.AreEqual("At 02:30 PM and 04:30 PM", ExpressionDescriptor.GetDescription("30 14,16 * * *"));
    Assert.AreEqual("At 06:30 AM, 02:30 PM and 04:30 PM", ExpressionDescriptor.GetDescription("30 6,14,16 * * *"));
    Assert.AreEqual("At 09:46 AM, only on Monday", ExpressionDescriptor.GetDescription("46 9 * * 1"));
    Assert.AreEqual("At 12:23 PM, on day 15 of the month", ExpressionDescriptor.GetDescription("23 12 15 * *"));
    Assert.AreEqual("At 12:23 PM, only in January", ExpressionDescriptor.GetDescription("23 12 * JAN *"));
    Assert.AreEqual("At 12:23 PM, only in January", ExpressionDescriptor.GetDescription("23 12 ? JAN *"));
    Assert.AreEqual("At 12:23 PM, January through February", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *"));
    Assert.AreEqual("At 12:23 PM, January through March", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *"));
    Assert.AreEqual("At 12:23 PM, only on Sunday", ExpressionDescriptor.GetDescription("23 12 * * SUN"));
    Assert.AreEqual("Every 05 minutes, at 03:00 PM, Monday through Friday", ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI"));
    Assert.AreEqual("Every minute, on the third Monday of the month", ExpressionDescriptor.GetDescription("* * * * MON#3"));
    Assert.AreEqual("Every minute, on the last Thursday of the month", ExpressionDescriptor.GetDescription("* * * * 4L"));
    Assert.AreEqual("Every 05 minutes, on the last day of the month, only in January", ExpressionDescriptor.GetDescription("*/5 * L JAN *"));
    Assert.AreEqual("At 02:02:30 PM", ExpressionDescriptor.GetDescription("30 02 14 * * *"));
    Assert.AreEqual("Seconds 05 through 10 past the minute", ExpressionDescriptor.GetDescription("5-10 * * * * *"));
    Assert.AreEqual("Seconds 05 through 10 past the minute, minutes 30 through 35 past the hour, between 10:00 AM and 12:00 PM", ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *"));
    Assert.AreEqual("At 30 seconds past the minute, every 05 minutes", ExpressionDescriptor.GetDescription("30 */5 * * * *"));
    Assert.AreEqual("At 30 minutes past the hour, between 10:00 AM and 01:00 PM, only on Wednesday and Friday", ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI"));
    Assert.AreEqual("At 10 seconds past the minute, every 05 minutes", ExpressionDescriptor.GetDescription("10 0/5 * * * ?"));
    Assert.AreEqual("Every 03 minutes, minutes 02 through 59 past the hour, at 01:00 AM, 09:00 AM, and 10:00 PM, between day 11 and 26 of the month, January through June", ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?"));
    Assert.AreEqual("At 06:00 AM", ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?"));
    Assert.AreEqual("At 05 minutes past the hour", ExpressionDescriptor.GetDescription("0 5 0/1 * * ?"));
    Assert.AreEqual("Every second, only in 2013", ExpressionDescriptor.GetDescription("* * * * * * 2013"));
    Assert.AreEqual("Every minute, only in 2013", ExpressionDescriptor.GetDescription("* * * * * 2013"));
    Assert.AreEqual("Every minute, only in 2013 and 2014", ExpressionDescriptor.GetDescription("* * * * * 2013,2014"));
    Assert.AreEqual("At 12:23 PM, January through February, 2013 through 2014", ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014"));
    Assert.AreEqual("At 12:23 PM, January through March, 2013 through 2015", ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015"));
