using Xunit;
using System.Globalization;
using System.Threading;

namespace CronExpressionDescriptor.Test.Support
{
    public abstract class BaseTestFormats
    {
        protected virtual string GetLocale()
        {
            return "en-US";
        }

        protected string GetDescription(string expression, bool verbose = false)
        {
            return GetDescription(expression, new Options() { Verbose = verbose });
        }

        protected string GetDescription(string expression, Options options)
        {
            options.Locale = this.GetLocale();
            return ExpressionDescriptor.GetDescription(expression, options);
        }
    }
}
