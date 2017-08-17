using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CronExpressionDescriptor.Test
{
    public class TestExceptions
    {
        [Fact]
        public void TestNullCronExpressionException()
        {
            Options options = new Options() { ThrowExceptionOnParseError = true };
            ExpressionDescriptor ceh = new ExpressionDescriptor(null, options);
            Assert.Throws<MissingFieldException>(() =>
            {
                ceh.GetDescription(DescriptionTypeEnum.FULL);
            });
        }

        [Fact]
        public void TestEmptyCronExpressionException()
        {
            Options options = new Options() { ThrowExceptionOnParseError = true };
            ExpressionDescriptor ceh = new ExpressionDescriptor(null, options);
            Assert.Throws<MissingFieldException>(() =>
            {
                ceh.GetDescription(DescriptionTypeEnum.FULL);
            });
        }

        [Fact]
        public void TestNullCronExpressionError()
        {
            Options options = new Options() { ThrowExceptionOnParseError = false };
            ExpressionDescriptor ceh = new ExpressionDescriptor(null, options);
            Assert.Equal("Field 'expression' not found.", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [Fact]
        public void TestInvalidCronExpressionException()
        {
            Options options = new Options() { ThrowExceptionOnParseError = true };
            ExpressionDescriptor ceh = new ExpressionDescriptor("INVALID", options);
            Assert.Throws<FormatException>(() =>
            {
                ceh.GetDescription(DescriptionTypeEnum.FULL);
            });
        }

        [Fact]
        public void TestInvalidCronExpressionError()
        {
            Options options = new Options() { ThrowExceptionOnParseError = false };
            ExpressionDescriptor ceh = new ExpressionDescriptor("INVALID CRON", options);
            Assert.Equal("Error: Expression only has 2 parts.  At least 5 part are required.", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [Fact]
        public void TestInvalidSyntaxException()
        {
            Options options = new Options() { ThrowExceptionOnParseError = true };
            ExpressionDescriptor ceh = new ExpressionDescriptor("* $ * * *", options);
            Assert.Throws<FormatException>(() =>
            {
                ceh.GetDescription(DescriptionTypeEnum.FULL);
            });

        }
    }
}
