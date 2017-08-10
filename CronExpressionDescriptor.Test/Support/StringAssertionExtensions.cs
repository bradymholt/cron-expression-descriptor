
using System;
using Xunit;

namespace CronExpressionDescriptor.Test.Support
{
    public class AssertExtensions : Xunit.Assert
    {
        public static void EqualsCaseInsensitive(string expectedSubString, string actualString)
        {
            Assert.Contains(expectedSubString, actualString, StringComparison.OrdinalIgnoreCase);
        }
    }
}