using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;

namespace CronExpressionDescriptor
{
  /// <summary>
  /// Cron Expression Parser
  /// </summary>
  public class ExpressionParser
  {
    /* Cron reference

      ┌───────────── minute (0 - 59)
      │ ┌───────────── hour (0 - 23)
      │ │ ┌───────────── day of month (1 - 31)
      │ │ │ ┌───────────── month (1 - 12)
      │ │ │ │ ┌───────────── day of week (0 - 6) (Sunday to Saturday; 7 is also Sunday on some systems)
      │ │ │ │ │
      │ │ │ │ │
      │ │ │ │ │
      * * * * *  command to execute

     */

    private string m_expression;
    private Options m_options;
    private CultureInfo m_en_culture;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpressionParser"/> class
    /// </summary>
    /// <param name="expression">The cron expression string</param>
    /// <param name="options">Parsing options</param>
    public ExpressionParser(string expression, Options options)
    {
      m_expression = expression;
      m_options = options;
      m_en_culture = new CultureInfo("en-US"); //Default to English
    }

    /// <summary>
    /// Parses the cron expression string
    /// </summary>
    /// <returns>A 7 part string array, one part for each component of the cron expression (seconds, minutes, etc.)</returns>
    public string[] Parse()
    {
      // Initialize all elements of parsed array to empty strings
      string[] parsed = new string[7].Select(el => "").ToArray();

      if (string.IsNullOrEmpty(m_expression))
      {
#if NET_STANDARD_1X
        throw new Exception("Field 'expression' not found.");
#else
        throw new MissingFieldException("Field 'expression' not found.");
#endif
      }
      else
      {
        string[] expressionPartsTemp = m_expression.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (expressionPartsTemp.Length < 5)
        {
          throw new FormatException(string.Format("Error: Expression only has {0} parts.  At least 5 part are required.", expressionPartsTemp.Length));
        }
        else if (expressionPartsTemp.Length == 5)
        {
          //5 part cron so shift array past seconds element
          Array.Copy(expressionPartsTemp, 0, parsed, 1, 5);
        }
        else if (expressionPartsTemp.Length == 6)
        {
          /* We will detect if this 6 part expression has a year specified and if so we will shift the parts and treat the 
             first part as a minute part rather than a second part. 

             Ways we detect:
               1. Last part is a literal year (i.e. 2020)
               2. 3rd or 5th part is specified as "?" (DOM or DOW)
          */                    
          bool isYearWithNoSecondsPart = Regex.IsMatch(expressionPartsTemp[5], "\\d{4}$") || expressionPartsTemp[4] == "?" || expressionPartsTemp[2] == "?";

          if (isYearWithNoSecondsPart)
          {
            // Shift parts over by one
            Array.Copy(expressionPartsTemp, 0, parsed, 1, 6);
          }
          else
          {
            Array.Copy(expressionPartsTemp, 0, parsed, 0, 6);
          }
        }
        else if (expressionPartsTemp.Length == 7)
        {
          parsed = expressionPartsTemp;
        }
        else
        {
          throw new FormatException(string.Format("Error: Expression has too many parts ({0}).  Expression must not have more than 7 parts.", expressionPartsTemp.Length));
        }
      }

      NormalizeExpression(parsed);

      return parsed;
    }

    /// <summary>
    /// Converts cron expression components into consistent, predictable formats.
    /// </summary>
    /// <param name="expressionParts">A 7 part string array, one part for each component of the cron expression</param>
    private void NormalizeExpression(string[] expressionParts)
    {
      // Convert ? to * only for DOM and DOW
      expressionParts[3] = expressionParts[3].Replace("?", "*");
      expressionParts[5] = expressionParts[5].Replace("?", "*");

      // Convert 0/, 1/ to */
      if (expressionParts[0].StartsWith("0/"))
      {
        // Seconds
        expressionParts[0] = expressionParts[0].Replace("0/", "*/");
      }

      if (expressionParts[1].StartsWith("0/"))
      {
        // Minutes
        expressionParts[1] = expressionParts[1].Replace("0/", "*/");
      }

      if (expressionParts[2].StartsWith("0/"))
      {
        // Hours
        expressionParts[2] = expressionParts[2].Replace("0/", "*/");
      }

      if (expressionParts[3].StartsWith("1/"))
      {
        // DOM
        expressionParts[3] = expressionParts[3].Replace("1/", "*/");
      }

      if (expressionParts[4].StartsWith("1/"))
      {
        // Month
        expressionParts[4] = expressionParts[4].Replace("1/", "*/");
      }

      if (expressionParts[5].StartsWith("1/"))
      {
        // DOW
        expressionParts[5] = expressionParts[5].Replace("1/", "*/");
      }

      if (expressionParts[6].StartsWith("1/"))
      {
        // Years
        expressionParts[6] = expressionParts[6].Replace("1/", "*/");
      }

      // Adjust DOW based on dayOfWeekStartIndexZero option
      expressionParts[5] = Regex.Replace(expressionParts[5], @"(^\d)|([^#/\s]\d)", t =>
      { //skip anything preceding by # or /
        string dowDigits = Regex.Replace(t.Value, @"\D", ""); // extract digit part (i.e. if "-2" or ",2", just take 2)
        string dowDigitsAdjusted = dowDigits;

        if (m_options.DayOfWeekStartIndexZero)
        {
          // "7" also means Sunday so we will convert to "0" to normalize it
          if (dowDigits == "7")
          {
            dowDigitsAdjusted = "0";
          }
        }
        else
        {
          // If dayOfWeekStartIndexZero==false, Sunday is specified as 1 and Saturday is specified as 7.
          // To normalize, we will shift the  DOW number down so that 1 becomes 0, 2 becomes 1, and so on.
          dowDigitsAdjusted = (Int32.Parse(dowDigits) - 1).ToString();
        }

        return t.Value.Replace(dowDigits, dowDigitsAdjusted);
      });

      // Convert DOM '?' to '*'
      if (expressionParts[3] == "?")
      {
        expressionParts[3] = "*";
      }

      // Convert SUN-SAT format to 0-6 format
      for (int i = 0; i <= 6; i++)
      {
        DayOfWeek currentDay = (DayOfWeek)i;
        string currentDayOfWeekDescription = currentDay.ToString().Substring(0, 3).ToUpperInvariant();
        expressionParts[5] = Regex.Replace(expressionParts[5], currentDayOfWeekDescription, i.ToString(), RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

      }

      // Convert JAN-DEC format to 1-12 format
      for (int i = 1; i <= 12; i++)
      {
        DateTime currentMonth = new DateTime(DateTime.Now.Year, i, 1);
        string currentMonthDescription = currentMonth.ToString("MMM", m_en_culture).ToUpperInvariant();
        expressionParts[4] = Regex.Replace(expressionParts[4], currentMonthDescription, i.ToString(), RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
      }

      // Convert 0 second to (empty)
      if (expressionParts[0] == "0")
      {
        expressionParts[0] = string.Empty;
      }

      // If time interval is specified for seconds or minutes and next time part is single item, make it a "self-range" so
      // the expression can be interpreted as an interval 'between' range.
      //     For example:
      //     0-20/3 9 * * * => 0-20/3 9-9 * * * (9 => 9-9)
      //     */5 3 * * * => */5 3-3 * * * (3 => 3-3)
      if (expressionParts[2].IndexOfAny(new char[] { '*', '-', ',', '/' }) == -1
        && (Regex.IsMatch(expressionParts[1], @"\*|\/") || Regex.IsMatch(expressionParts[0], @"\*|\/")))
      {
        expressionParts[2] += $"-{expressionParts[2]}";
      }

      // Loop through all parts and apply global normalization
      for (int i = 0; i < expressionParts.Length; i++)
      {
        // convert all '*/1' to '*'
        if (expressionParts[i] == "*/1")
        {
          expressionParts[i] = "*";
        }

        /* Convert Month,DOW,Year step values with a starting value (i.e. not '*') to between expressions.
           This allows us to reuse the between expression handling for step values.

           For Example:
            - month part '3/2' will be converted to '3-12/2' (every 2 months between March and December)
            - DOW part '3/2' will be converted to '3-6/2' (every 2 days between Tuesday and Saturday)
        */

        if (expressionParts[i].Contains("/")
            && expressionParts[i].IndexOfAny(new char[] { '*', '-', ',' }) == -1)
        {
          string stepRangeThrough = null;
          switch (i)
          {
            case 4: stepRangeThrough = "12"; break;
            case 5: stepRangeThrough = "6"; break;
            case 6: stepRangeThrough = "9999"; break;
            default: stepRangeThrough = null; break;
          }

          if (stepRangeThrough != null)
          {
            string[] parts = expressionParts[i].Split('/');
            expressionParts[i] = string.Format("{0}-{1}/{2}", parts[0], stepRangeThrough, parts[1]);
          }
        }
      }
    }
  }
}
