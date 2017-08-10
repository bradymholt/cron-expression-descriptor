# Cron Expression Descriptor
A .NET library that converts cron expressions into human readable descriptions.

[![Build Status](https://img.shields.io/travis/bradyholt/cron-expression-descriptor.svg?branch=master)](https://travis-ci.org/bradyholt/cron-expression-descriptor)
[![NuGet Version and Downloads count](https://buildstats.info/nuget/CronExpressionDescriptor)](https://www.nuget.org/packages/CronExpressionDescriptor/)

**Author**: Brady Holt (http://www.geekytidbits.com)
**Contributors**: Renato Lima, Ivan Santos, Fabien Brooke, Siarhei Khalipski, Mustafa SADEDİL, TotalMace, Star Peng, LbISS, Arnaud TAMAILLON, Michael Schuler, Taras(tbudurovych)
**License**: [MIT](https://github.com/bradyholt/cron-expression-descriptor/blob/dotnet-core/LICENSE)

## Features

 * Supports all cron expression special characters including * / , - ? L W, #
 * Supports 5, 6 (w/ seconds or year), or 7 (w/ seconds and year) part cron expressions
 * Provides casing options (Sentence, Title, Lower, etc.)
 * Localization with support for 15 languages

## i18n

The following language translations are available.

 * English - en ([Brady Holt](https://github.com/bradyholt))
 * Brazilian Portuguese - pt-BR ([Renato Lima](https://github.com/natenho))
 * Spanish - es ([Ivan Santos](https://github.com/ivansg))
 * Norwegian - nb ([Siarhei Khalipski](https://github.com/KhalipskiSiarhei))
 * Turkish - tr ([Mustafa SADEDİL](https://github.com/sadedil))
 * Dutch - nl ([TotalMace](https://github.com/TotalMace))
 * Chinese Simplified - zh-CH ([Star Peng](https://github.com/starpeng))
 * Russian - ru ([LbISS](https://github.com/LbISS))
 * French - fr ([Arnaud TAMAILLON](https://github.com/Greybird))
 * German - de ([Michael Schuler](https://github.com/mschuler))
 * Ukrainian - uk ([Taras](https://github.com/tbudurovych))
 * Italian - it ([rinaldihno](https://github.com/rinaldihno))
 * Polish - pl ([foka](https://github.com/foka))
 * Romanian - ro ([Illegitimis](https://github.com/illegitimis))
 * Swedish - sv ([roobin](https://github.com/roobin))

To use one of these translations, pass in the `Locale` option to `GetDescription`.  For example, to get the description of `0-10 11 * * *` in German:

```
ExpressionDescriptor.GetDescription("0-10 11 * * *", new Options(){ Locale = "de" });
> "Jede Minute zwischen 11:00 und 11:10"
```

Alternatively, you can call `ExpressionDescriptor.SetDefaultLocale("es");` first to set the default locale and then every usage will use this locale by default.

```
ExpressionDescriptor.SetDefaultLocale("es");

ExpressionDescriptor.GetDescription("*/45 * * * * *");
> "Cada 45 segundos"
ExpressionDescriptor.GetDescription("0-10 11 * * *");
> "Cada minuto entre las 11:00 AM y las 11:10 AM"
```

### CurrentUICulture

In earlier versions of Cron Expression Descriptor, [Thread.CurrentUICulture](https://msdn.microsoft.com/en-us/library/system.threading.thread.currentuiculture(v=vs.110).aspx) was supported so the following would work:
```
CultureInfo myCultureInfo = new CultureInfo("it-IT");
Thread.CurrentThread.CurrentUICulture = myCultureInfo;
ExpressionDescriptor.GetDescription("* * * * *");
> "Ogni minuto"
```

If you need CurrentUICulture support, use version 1.21.2 (`Install-Package CronExpressionDescriptor -Version 1.21.2`), the latest version with this support.

## Options

An `CronExpressionDescriptor.Options` object can be passed to `GetDescription`.  The following options are available:

- **bool ThrowExceptionOnParseError** - If exception when trying to parse expression and generate description, whether to throw or catch and output the Exception message as the description. (Default: true)
- **bool Verbose** - Whether to use a verbose description (Default: false)
- **bool DayOfWeekStartIndexZero** - Whether to interpret cron expression DOW `1` as Sunday or Monday. (Default: true)
- **?bool Use24HourTimeFormat** - If true, descriptions will use a [24-hour clock](https://en.wikipedia.org/wiki/24-hour_clock) (Default: false but some translations will default to true)
- **string Locale** - The locale to use (Default: "en")

Example usage:

```
ExpressionDescriptor.GetDescription("0-10 11 * * *", new Options(){
    DayOfWeekStartIndexZero = false,
    Use24HourTimeFormat = true,
    Locale = "fr"
});
```

## Demo

[http://cronexpressiondescriptor.azurewebsites.net](http://cronexpressiondescriptor.azurewebsites.net)

## Download

Cron Expression Descriptor releases can be installed with **NuGet**.  [Visit the NuGet Package page](https://www.nuget.org/packages/CronExpressionDescriptor/) for more info.

View [Releases](https://github.com/bradyholt/cron-expression-descriptor/releases) for release version history.

## Ports

 - Java - [https://github.com/RedHogs/cron-parser](https://github.com/RedHogs/cron-parser)
 - Ruby - [https://github.com/alpinweis/cronex](https://github.com/alpinweis/cronex)
 - Python - [https://github.com/Salamek/cron-descriptor](https://github.com/Salamek/cron-descriptor)
 - JavaScript - [https://github.com/bradyholt/cronstrue](https://github.com/bradyholt/cronstrue)

## Examples

ExpressionDescriptor.GetDescription("* * * * *");
> "Every minute"

ExpressionDescriptor.GetDescription("*/1 * * * *");
> "Every minute"

ExpressionDescriptor.GetDescription("0 0/1 * * * ?");
> "Every minute"

ExpressionDescriptor.GetDescription("0 0 * * * ?");
> "Every hour"

ExpressionDescriptor.GetDescription("0 0 0/1 * * ?");
> "Every hour"

ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI");
> "At 11:00 PM, Monday through Friday"

ExpressionDescriptor.GetDescription("* * * * * *");
> "Every second"

ExpressionDescriptor.GetDescription("*/45 * * * * *");
> "Every 45 seconds"

ExpressionDescriptor.GetDescription("*/5 * * * *");
> "Every 5 minutes"

ExpressionDescriptor.GetDescription("0 0/10 * * * ?");
> "Every 10 minutes"

ExpressionDescriptor.GetDescription("0 */5 * * * *");
> "Every 5 minutes"

ExpressionDescriptor.GetDescription("30 11 * * 1-5");
> "At 11:30 AM, Monday through Friday"

ExpressionDescriptor.GetDescription("30 11 * * *");
> "At 11:30 AM"

ExpressionDescriptor.GetDescription("0-10 11 * * *");
> "Every minute between 11:00 AM and 11:10 AM"

ExpressionDescriptor.GetDescription("* * * 3 *");
> "Every minute, only in March"

ExpressionDescriptor.GetDescription("* * * 3,6 *");
> "Every minute, only in March and June"

ExpressionDescriptor.GetDescription("30 14,16 * * *");
> "At 02:30 PM and 04:30 PM"

ExpressionDescriptor.GetDescription("30 6,14,16 * * *");
> "At 06:30 AM, 02:30 PM and 04:30 PM"

ExpressionDescriptor.GetDescription("46 9 * * 1");
> "At 09:46 AM, only on Monday"

ExpressionDescriptor.GetDescription("23 12 15 * *");
> "At 12:23 PM, on day 15 of the month"

ExpressionDescriptor.GetDescription("23 12 * JAN *");
> "At 12:23 PM, only in January"

ExpressionDescriptor.GetDescription("23 12 ? JAN *");
> "At 12:23 PM, only in January"

ExpressionDescriptor.GetDescription("23 12 * JAN-FEB *");
> "At 12:23 PM, January through February"

ExpressionDescriptor.GetDescription("23 12 * JAN-MAR *");
> "At 12:23 PM, January through March"

ExpressionDescriptor.GetDescription("23 12 * * SUN");
> "At 12:23 PM, only on Sunday"

ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI");
> "Every 5 minutes, at 03:00 PM, Monday through Friday"

ExpressionDescriptor.GetDescription("* * * * MON#3");
> "Every minute, on the third Monday of the month"

ExpressionDescriptor.GetDescription("* * * * 4L");
> "Every minute, on the last Thursday of the month"

ExpressionDescriptor.GetDescription("*/5 * L JAN *");
> "Every 5 minutes, on the last day of the month, only in January"

ExpressionDescriptor.GetDescription("30 02 14 * * *");
> "At 02:02:30 PM"

ExpressionDescriptor.GetDescription("5-10 * * * * *");
> "Seconds 5 through 10 past the minute"

ExpressionDescriptor.GetDescription("5-10 30-35 10-12 * * *");
> "Seconds 5 through 10 past the minute, minutes 30 through 35 past the hour, between 10:00 AM and 12:00 PM"

ExpressionDescriptor.GetDescription("30 */5 * * * *");
> "At 30 seconds past the minute, every 05 minutes"

ExpressionDescriptor.GetDescription("0 30 10-13 ? * WED,FRI");
> "At 30 minutes past the hour, between 10:00 AM and 01:00 PM, only on Wednesday and Friday"

ExpressionDescriptor.GetDescription("10 0/5 * * * ?");
> "At 10 seconds past the minute, every 05 minutes"

ExpressionDescriptor.GetDescription("2-59/3 1,9,22 11-26 1-6 ?");
> "Every 03 minutes, minutes 2 through 59 past the hour, at 01:00 AM, 09:00 AM, and 10:00 PM, between day 11 and 26 of the month, January through June"

ExpressionDescriptor.GetDescription("0 0 6 1/1 * ?");
> "At 06:00 AM"

ExpressionDescriptor.GetDescription("0 5 0/1 * * ?");
> "At 05 minutes past the hour"

ExpressionDescriptor.GetDescription("* * * * * * 2013");
> "Every second, only in 2013"

ExpressionDescriptor.GetDescription("* * * * * 2013");
> "Every minute, only in 2013"

ExpressionDescriptor.GetDescription("* * * * * 2013,2014");
> "Every minute, only in 2013 and 2014"

ExpressionDescriptor.GetDescription("23 12 * JAN-FEB * 2013-2014");
> "At 12:23 PM, January through February, 2013 through 2014"

ExpressionDescriptor.GetDescription("23 12 * JAN-MAR * 2013-2015");
> "At 12:23 PM, January through March, 2013 through 2015"
