﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace CronExpressionDescriptor
{
    public class ExpressionParser
    {
        private string m_expression;
        private Options m_options;
        private CultureInfo m_en_culture;

        public ExpressionParser(string expression, Options options)
        {
            m_expression = expression;
            m_options = options;
            m_en_culture = new CultureInfo("en");
        }

        public string[] Parse()
        {
            // Initialize all elements of parsed array to empty strings
            string[] parsed = new string[7].Select(el => "").ToArray();

            if (string.IsNullOrEmpty(m_expression))
            {
                throw new MissingFieldException("ExpressionDescriptor", "expression");
            }
            else
            {
                string[] expressionPartsTemp = m_expression.Split(' ');

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
                    //If last element ends with 4 digits, a year element has been supplied and no seconds element
                    Regex yearRegex = new Regex("\\d{4}$");
                    if (yearRegex.IsMatch(expressionPartsTemp[5]))
                    {
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

        private void NormalizeExpression(string[] expressionParts)
        {
            //convert ? to * only for DOM and DOW
            expressionParts[3] = expressionParts[3].Replace("?", "*");
            expressionParts[5] = expressionParts[5].Replace("?", "*");

            //convert 0/, 1/ to */
            expressionParts[0] = expressionParts[0].Replace("0/", "*/"); //seconds
            expressionParts[1] = expressionParts[1].Replace("0/", "*/"); //minutes
            expressionParts[2] = expressionParts[2].Replace("0/", "*/"); //hours
            expressionParts[3] = expressionParts[3].Replace("1/", "*/"); //DOM
            expressionParts[4] = expressionParts[4].Replace("1/", "*/"); //Month
            expressionParts[5] = expressionParts[5].Replace("1/", "*/"); //DOW

            //convert */1 to *
            int len = expressionParts.Length;
            for (int i = 0; i < len; i++)
            {
                if (expressionParts[i] == "*/1")
                {
                    expressionParts[i] = "*";
                }
            }

            //convert SUN-SAT format to 0-6 format
            for (int i = 0; i <= 6; i++)
            {
                if (!m_options.DayOfWeekStartIndexZero)
                {
                    expressionParts[5] = expressionParts[5].Replace((i + 1).ToString(), i.ToString());
                }

                DayOfWeek currentDay = (DayOfWeek)i;
                string currentDayOfWeekDescription = currentDay.ToString().Substring(0, 3).ToUpper();
                expressionParts[5] = expressionParts[5].Replace(currentDayOfWeekDescription, i.ToString());
            }

            //convert  JAN-DEC format to 1-12 format
            for (int i = 1; i <= 12; i++)
            {
                DateTime currentMonth = new DateTime(DateTime.Now.Year, i, 1);
                string currentMonthDescription = currentMonth.ToString("MMM",m_en_culture).ToUpper();
                expressionParts[4] = expressionParts[4].Replace(currentMonthDescription, i.ToString());
            }

            //convert 0 second to (empty)
            if (expressionParts[0] == "0")
            {
                expressionParts[0] = string.Empty;
            }
        }
    }
}
