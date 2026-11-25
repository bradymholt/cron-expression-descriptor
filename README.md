# Cron Expression Descriptor

[![Build](https://github.com/bradymholt/cron-expression-descriptor/actions/workflows/build.yml/badge.svg)](https://github.com/bradymholt/cron-expression-descriptor/actions/workflows/build.yml)
[![NuGet](https://img.shields.io/nuget/v/CronExpressionDescriptor.svg)](https://www.nuget.org/packages/CronExpressionDescriptor/)
[![NuGet downloads](https://img.shields.io/nuget/dt/CronExpressionDescriptor.svg)](https://www.nuget.org/packages/CronExpressionDescriptor/)
[![.NET 10 | .NET Standard 2.0](https://img.shields.io/badge/.NET%2010%20%7C%20.NET%20Standard%202.0-512BD4.svg)](#net-platform-support)
[![License: MIT](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/bradymholt/cron-expression-descriptor/blob/master/LICENSE)

<img align="left" src="https://user-images.githubusercontent.com/759811/210273710-b13913e2-0a71-4d9d-94da-1fe538b8a73e.gif"/>

<br/>

 &nbsp;**Would you take a quick second and ⭐️ my repo?**

<br/>

A .NET library that converts cron expressions into human readable descriptions.

```csharp
ExpressionDescriptor.GetDescription("0 23 ? * MON-FRI");
// "At 11:00 PM, Monday through Friday"
```

**[Try it live →](https://bradymholt.github.io/cron-expression-descriptor/)**

## Contents

- [Features](#features)
- [Installation](#installation)
- [Quick Start](#quick-start)
- [Options](#options)
- [Languages](#languages)
- [Examples](#examples)
- [.NET Platform Support](#net-platform-support)
- [Ports](#ports)
- [FAQ](#faq)

## Features

- Supports all cron expression special characters including `*` `/` `,` `-` `?` `L` `W` `#`
- Supports 5, 6 (with seconds or year), or 7 (with seconds and year) part cron expressions
- [30 languages](#languages)
- Supports [Quartz.NET](https://www.quartz-scheduler.net/) cron expressions
- 12 or 24-hour time

## Installation

```bash
dotnet add package CronExpressionDescriptor
```

See the [NuGet package](https://www.nuget.org/packages/CronExpressionDescriptor/) and [release notes](https://github.com/bradymholt/cron-expression-descriptor/releases).

## Quick Start

```csharp
using CronExpressionDescriptor;

ExpressionDescriptor.GetDescription("*/5 15 * * MON-FRI");
// "Every 5 minutes, between 03:00 PM and 03:59 PM, Monday through Friday"
```

## Options

Pass an `Options` object to `GetDescription`:

| Option | Type | Default | Description |
| --- | --- | --- | --- |
| `ThrowExceptionOnParseError` | `bool` | `true` | Throw when the expression can't be described, or return the error message as the description |
| `Verbose` | `bool` | `false` | Keep parts like ", every minute" that only restate the default |
| `DayOfWeekStartIndexZero` | `bool` | `true` | Whether day of week `0` is Sunday (`true`) or `1` is Sunday (`false`) |
| `Use24HourTimeFormat` | `bool?` | `null` | Use a [24-hour clock](https://en.wikipedia.org/wiki/24-hour_clock); when `null`, the locale decides |
| `Locale` | `string` | `null` | The language to describe the expression in; when `null`, [`CurrentUICulture`](#currentuiculture) is used |

```csharp
ExpressionDescriptor.GetDescription("0-10 11 * * *", new Options
{
    DayOfWeekStartIndexZero = false,
    Use24HourTimeFormat = true,
    Locale = "fr"
});
// "Toutes les minutes entre 11:00 et 11:10"
```

## Languages

Pass a `Locale` to describe an expression in another language:

```csharp
ExpressionDescriptor.GetDescription("0-10 11 * * *", new Options { Locale = "de" });
// "Jede Minute zwischen 11:00 und 11:10"
```

| Language | Locale | Contributor |
| --- | --- | --- |
| English | `en` | [Brady Holt](https://github.com/bradymholt) |
| Chinese (Simplified) | `zh-Hans` (`zh-CN`) | [Star Peng](https://github.com/starpeng) |
| Chinese (Traditional) | `zh-Hant` (`zh-TW`) | [Ricky Chiang](https://github.com/metavige) |
| Czech | `cs` | [Jirka](https://github.com/Betacart) |
| Danish | `da` | [Rasmus Melchior Jacobsen](https://github.com/rmja) |
| Dutch | `nl` | [TotalMace](https://github.com/TotalMace) |
| Finnish | `fi` | [Mikael Rosenberg](https://github.com/MR77FI) |
| French | `fr` | [Arnaud TAMAILLON](https://github.com/Greybird) |
| German | `de` | [Michael Schuler](https://github.com/mschuler) |
| Greek | `el` | [hardra1n](https://github.com/Hardra1n) |
| Hebrew | `he-IL` | [Ariel Deil](https://github.com/arieldeil) |
| Hungarian | `hu` | [Varga Miklós](https://github.com/Micky2149) |
| Italian | `it` | [rinaldihno](https://github.com/rinaldihno) |
| Japanese | `ja` | [Alin Sarivan](https://github.com/asarivan) |
| Kazakh | `kk` | [hardra1n](https://github.com/Hardra1n) |
| Korean | `ko` | [Ion Mincu](https://github.com/ionmincu) |
| Kyrgyz | `ky` | [Only Human](https://github.com/kgz77) |
| Norwegian | `nb` | [Siarhei Khalipski](https://github.com/KhalipskiSiarhei) |
| Persian (Farsi) | `fa` | [A. Bahrami](https://github.com/alirezakoo) |
| Polish | `pl` | [foka](https://github.com/foka) |
| Portuguese (Brazil) | `pt` | [Renato Lima](https://github.com/natenho) |
| Romanian | `ro` | [Illegitimis](https://github.com/illegitimis) |
| Russian | `ru` | [LbISS](https://github.com/LbISS) |
| Slovenian | `sl` | [Jani Bevk](https://github.com/jenzy) |
| Spanish | `es` | [Ivan Santos](https://github.com/ivansg) |
| Spanish (Mexico) | `es-MX` | [Ion Mincu](https://github.com/ionmincu) |
| Swedish | `sv` | [roobin](https://github.com/roobin) |
| Turkish | `tr` | [Mustafa SADEDİL](https://github.com/sadedil) |
| Ukrainian | `uk` | [Taras](https://github.com/tbudurovych) |
| Vietnamese | `vi` | [Nguyen Duc Son](https://github.com/ali33) |

Want to add a language? See [CONTRIBUTING.md](https://github.com/bradymholt/cron-expression-descriptor/blob/master/CONTRIBUTING.md#i18n).

### CurrentUICulture

When no `Locale` is passed, [`Thread.CurrentUICulture`](https://learn.microsoft.com/en-us/dotnet/api/system.threading.thread.currentuiculture) decides the language:

```csharp
Thread.CurrentThread.CurrentUICulture = new CultureInfo("it-IT");
ExpressionDescriptor.GetDescription("* * * * *");
// "Ogni minuto"
```

### Reducing build output size

To leave out languages you don't need, set the [`SatelliteResourceLanguages`](https://learn.microsoft.com/en-us/dotnet/core/project-sdk/msbuild-props#satelliteresourcelanguages) property in your project.

## Examples

| Expression | Description |
| --- | --- |
| `* * * * *` | Every minute |
| `*/5 * * * *` | Every 5 minutes |
| `0 * * * *` | Every hour |
| `30 11 * * *` | At 11:30 AM |
| `30 11 * * 1-5` | At 11:30 AM, Monday through Friday |
| `0 23 ? * MON-FRI` | At 11:00 PM, Monday through Friday |
| `0-10 11 * * *` | Every minute between 11:00 AM and 11:10 AM |
| `30 6,14,16 * * *` | At 06:30 AM, 02:30 PM and 04:30 PM |
| `*/5 15 * * MON-FRI` | Every 5 minutes, between 03:00 PM and 03:59 PM, Monday through Friday |
| `23 12 15 * *` | At 12:23 PM, on day 15 of the month |
| `* * * 3,6 *` | Every minute, only in March and June |
| `23 12 * JAN-MAR *` | At 12:23 PM, January through March |
| `* * * * MON#3` | Every minute, on the third Monday of the month |
| `* * * * 4L` | Every minute, on the last Thursday of the month |
| `*/5 * L JAN *` | Every 5 minutes, on the last day of the month, only in January |
| `* * * * * *` | Every second |
| `*/45 * * * * *` | Every 45 seconds |
| `30 02 14 * * *` | At 02:02:30 PM |
| `5-10 30-35 10-12 * * *` | Seconds 5 through 10 past the minute, minutes 30 through 35 past the hour, between 10:00 AM and 12:59 PM |
| `0 30 10-13 ? * WED,FRI` | At 30 minutes past the hour, between 10:00 AM and 01:59 PM, only on Wednesday and Friday |
| `2-59/3 1,9,22 11-26 1-6 ?` | Every 3 minutes, minutes 2 through 59 past the hour, at 01:00 AM, 09:00 AM, and 10:00 PM, between day 11 and 26 of the month, January through June |
| `* * * * * 2013,2014` | Every minute, only in 2013 and 2014 |
| `23 12 * JAN-FEB * 2013-2014` | At 12:23 PM, January through February, 2013 through 2014 |

## .NET Platform Support

The NuGet package targets .NET Standard 2.0 and .NET 10.0, so it runs on:

- .NET Core >= 2.0 and .NET >= 5.0
- .NET Framework >= 4.6.1
- Mono >= 5.4
- [Other .NET Standard 2.0 platforms](https://learn.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-0)

### Older platforms

| You need | Use version |
| --- | --- |
| .NET Standard 1.x (e.g. .NET Core 1.x, .NET Framework 4.5) | `2.52.0` |
| .NET Framework 3.5 or 4.0 | `1.21.2` |
| A [strong-named](https://learn.microsoft.com/en-us/dotnet/standard/assembly/strong-named) assembly | `1.21.2` |

```bash
dotnet add package CronExpressionDescriptor --version 1.21.2
```

## Ports

This library has been ported to several other languages:

| Language | Project |
| --- | --- |
| JavaScript | [bradymholt/cRonstrue](https://github.com/bradymholt/cRonstrue) |
| Java | [RedHogs/cron-parser](https://github.com/RedHogs/cron-parser) |
| Java | [voidburn/cron-expression-descriptor](https://github.com/voidburn/cron-expression-descriptor) |
| Ruby | [alpinweis/cronex](https://github.com/alpinweis/cronex) |
| Python | [Salamek/cron-descriptor](https://github.com/Salamek/cron-descriptor) |
| PHP | [panlatent/cron-expression-descriptor](https://github.com/panlatent/cron-expression-descriptor) |
| Go | [lnquy/cron](https://github.com/lnquy/cron) |
| Rust | [cflockhart/cron-descriptor-rust](https://github.com/cflockhart/cron-descriptor-rust) |
| Swift | [gooop/cron-descriptor-swift](https://github.com/gooop/cron-descriptor-swift) |

## FAQ

**The cron expression I'm passing in is not valid and the output is strange. What should I do?**

This library does not fully validate cron expressions and assumes the expression is valid. To validate one, use a library like [Cronos](https://github.com/HangfireIO/Cronos).

**Can this library show the next scheduled date?**

No. [Cronos](https://github.com/HangfireIO/Cronos) can.

## License

[MIT](https://github.com/bradymholt/cron-expression-descriptor/blob/master/LICENSE) © [Brady Holt](https://www.geekytidbits.com)
