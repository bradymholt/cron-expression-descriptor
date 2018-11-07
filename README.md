# Cron Expression Descriptor
A .NET library that converts cron expressions into human readable descriptions.

[![Build Status](https://travis-ci.org/bradymholt/cron-expression-descriptor.svg?branch=master)](https://travis-ci.org/bradymholt/cron-expression-descriptor)
[![NuGet version](https://badge.fury.io/nu/CronExpressionDescriptor.svg)](https://badge.fury.io/nu/CronExpressionDescriptor)

**Author**: Brady Holt (http://www.geekytidbits.com)
**License**: [MIT](https://github.com/bradymholt/cron-expression-descriptor/blob/dotnet-core/LICENSE)

## Features

 * Supports all cron expression special characters including * / , - ? L W, #
 * Supports 5, 6 (w/ seconds or year), or 7 (w/ seconds and year) part cron expressions
 * Provides casing options (Sentence, Title, Lower, etc.)
 * Localization with support for 20 languages
 * Supports [Quartz Enterprise Scheduler .NET](https://www.quartz-scheduler.net/) cron expressions

## Download

Cron Expression Descriptor releases can be installed with **NuGet**.

### Package Manager (Visual Studio)

    Install-Package CronExpressionDescriptor

### .NET CLI

    dotnet add package CronExpressionDescriptor

[Visit the NuGet Package page](https://www.nuget.org/packages/CronExpressionDescriptor/) for more info.

View [Releases](https://github.com/bradymholt/cron-expression-descriptor/releases) for release version history.

## Quick Start

```csharp
CronExpressionDescriptor.ExpressionDescriptor.GetDescription("* * * * *");
> "Every minute"
```

## Options

A `CronExpressionDescriptor.Options` object can be passed to `GetDescription`.  The following options are available:

- **bool ThrowExceptionOnParseError** - If exception when trying to parse expression and generate description, whether to throw or catch and output the Exception message as the description. (Default: true)
- **bool Verbose** - Whether to use a verbose description (Default: false)
- **bool DayOfWeekStartIndexZero** - Whether to interpret cron expression DOW `1` as Sunday or Monday. (Default: true)
- **?bool Use24HourTimeFormat** - If true, descriptions will use a [24-hour clock](https://en.wikipedia.org/wiki/24-hour_clock) (Default: false but some translations will default to true)
- **string Locale** - The locale to use (Default: "en")

Example usage:

```csharp
ExpressionDescriptor.GetDescription("0-10 11 * * *", new Options(){
    DayOfWeekStartIndexZero = false,
    Use24HourTimeFormat = true,
    Locale = "fr"
});
```

## i18n

The following language translations are available.

 * English - en ([Brady Holt](https://github.com/bradymholt))
 * Chinese Simplified - zh-Hans (zh-CN) ([Star Peng](https://github.com/starpeng))
 * Chinese Traditional - zh-Hant (zh-TW) ([Ricky Chiang](https://github.com/metavige))
 * Danish - da ([Rasmus Melchior Jacobsen](https://github.com/rmja))
 * Dutch - nl ([TotalMace](https://github.com/TotalMace))
 * Finnish - fi ([Mikael Rosenberg](https://github.com/MR77FI))
 * French - fr ([Arnaud TAMAILLON](https://github.com/Greybird))
 * German - de ([Michael Schuler](https://github.com/mschuler))
 * Italian - it ([rinaldihno](https://github.com/rinaldihno))
 * Japanese - ja ([Alin Sarivan](https://github.com/asarivan))
 * Norwegian - nb ([Siarhei Khalipski](https://github.com/KhalipskiSiarhei))
 * Polish - pl ([foka](https://github.com/foka))
 * Portuguese (Brazil) - pt-BR ([Renato Lima](https://github.com/natenho))
 * Romanian - ro ([Illegitimis](https://github.com/illegitimis))
 * Russian - ru ([LbISS](https://github.com/LbISS))
 * Slovenian - sl-SI ([Jani Bevk](https://github.com/jenzy))
 * Spanish - es ([Ivan Santos](https://github.com/ivansg))
 * Swedish - sv ([roobin](https://github.com/roobin))
 * Turkish - tr ([Mustafa SADEDİL](https://github.com/sadedil))
 * Ukrainian - uk ([Taras](https://github.com/tbudurovych))
 
To use one of these translations, pass in the `Locale` option to `GetDescription`.  For example, to get the description of `0-10 11 * * *` in German:

```csharp
ExpressionDescriptor.GetDescription("0-10 11 * * *", new Options(){ Locale = "de" });
> "Jede Minute zwischen 11:00 und 11:10"
```

Alternatively, you can call `ExpressionDescriptor.SetDefaultLocale("es");` first to set the default locale and then every usage will use this locale by default.

```csharp
ExpressionDescriptor.SetDefaultLocale("es");

ExpressionDescriptor.GetDescription("*/45 * * * * *");
> "Cada 45 segundos"

ExpressionDescriptor.GetDescription("0-10 11 * * *");
> "Cada minuto entre las 11:00 AM y las 11:10 AM"
```

### CurrentUICulture

If you are targeting a platform that [supports .NET Standard >= 2.0](https://github.com/dotnet/standard/blob/master/docs/versions.md), [Thread.CurrentUICulture](https://msdn.microsoft.com/en-us/library/system.threading.thread.currentuiculture(v=vs.110).aspx) is supported for determining the default locale, without explicitly passing it in with the `Locale` option, so the following will work:

```csharp
// .NET Standard >= 2.0 only
CultureInfo myCultureInfo = new CultureInfo("it-IT");
Thread.CurrentThread.CurrentUICulture = myCultureInfo;
ExpressionDescriptor.GetDescription("* * * * *");
> "Ogni minuto"
```

## .NET Platform Support

Beginning with version 2.0.0, the NuGet package will contain a library targeting .NET Standard 1.1 and 2.0.  This allows the library to be consumed by applications running on the following .NET platforms:

- .NET Core >= 1.0
- .NET Framework >= 4.5
- Mono >= 4.6
- ([More](https://github.com/dotnet/standard/blob/master/docs/versions.md))

If your application is targeting an earlier version of .NET Framework (i.e. 4.0 or 3.5), you can use version `1.21.2` as it has support back to .NET Framework 3.5.  To install this version, run `Install-Package CronExpressionDescriptor -Version 1.21.2`.

### Strong Name Signing

If you need an assembly that is [signed with a strong name](https://msdn.microsoft.com/en-us/library/wd40t7ad(v=vs.100).aspx), you can use version 1.21.2 as it is currently the latest version signed with a strong name.

## Demo

[https://cronexpressiondescriptor.azurewebsites.net](http://cronexpressiondescriptor.azurewebsites.net)

## Ports

 - Java - [https://github.com/RedHogs/cron-parser](https://github.com/RedHogs/cron-parser)
 - Ruby - [https://github.com/alpinweis/cronex](https://github.com/alpinweis/cronex)
 - Python - [https://github.com/Salamek/cron-descriptor](https://github.com/Salamek/cron-descriptor)
 - JavaScript - [https://github.com/bradymholt/cRonstrue](https://github.com/bradymholt/cRonstrue)

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
> "Every 5 minutes, between 03:00 PM and 03:59 PM, Monday through Friday"

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
