using CronExpressionDescriptor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace CronExpressionDescriptorDemo.Controllers
{
    public class DefaultController : Controller
    {
        private const string DEFAULT_EXPRESSION = "0 30 10-13 ? * WED,FRI";

        public ActionResult Index(ViewModel model)
        {
            if (model.Expression == null)
            {
                model.Expression = DEFAULT_EXPRESSION;
            }

            EvaluateExpression(model);
            return View(model);
        }

        private void EvaluateExpression(ViewModel model)
        {
            Options options = new Options() { ThrowExceptionOnParseError = false };
            options.Use24HourTimeFormat = model.Use24HourFormat;
            options.DayOfWeekStartIndexZero = !model.DayOfWeekStartIndexOne;
            options.Verbose = model.VerboseDescription;

            if (!string.IsNullOrEmpty(model.Language))
            {
                CultureInfo myCultureInfo = new CultureInfo(model.Language);
                Thread.CurrentThread.CurrentCulture = myCultureInfo;
                Thread.CurrentThread.CurrentUICulture = myCultureInfo;
            }

            model.ExpressionDescription = ExpressionDescriptor.GetDescription(model.Expression, options);
        }
    }
}