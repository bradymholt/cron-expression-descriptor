
using System;
using Xunit;

namespace CronExpressionDescriptor.Test.Support
{
    public class AssertExtensions : Xunit.Assert
    {
        public static void EqualsCaseInsensitive(string actualString,
                                             string expectedSubString)
        {
            Assert.Contains(expectedSubString, actualString, StringComparison.OrdinalIgnoreCase);
        }
    }
}