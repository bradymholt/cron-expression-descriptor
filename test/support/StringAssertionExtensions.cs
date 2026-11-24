
using System;
using Xunit;

namespace CronExpressionDescriptor.Test.Support
{
    public class AssertExtensions : Xunit.Assert
    {
        public static void ContainsCaseInsensitive(string expectedSubstring, string actualString)
        {
            Assert.Contains(expectedSubstring, actualString, StringComparison.OrdinalIgnoreCase);
        }
    }
}