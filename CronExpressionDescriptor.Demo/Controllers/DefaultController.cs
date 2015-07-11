using CronExpressionDescriptor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CronExpressionDescriptorDemo.Controllers
{
    public class DefaultController : Controller
    {
        private const string DEFAULT_EXPRESSION = "0 30 10-13 ? * WED,FRI";

        public ActionResult Index(string e)
        {
            SetVersionViewBag();
            EvaluateExpression(e ?? DEFAULT_EXPRESSION);
            return View();
        }

        private void EvaluateExpression(string expression)
        {
            Options options = new Options() { ThrowExceptionOnParseError = false };

            ViewBag.Expression = expression;
            ViewBag.Description = ExpressionDescriptor.GetDescription(expression, options);
        }

        private void SetVersionViewBag()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(ExpressionDescriptor));
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            ViewBag.ExpressionDescriptorVersion = fvi.FileVersion;
        }
    }
}