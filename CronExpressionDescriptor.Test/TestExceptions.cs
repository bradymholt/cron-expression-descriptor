using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CronExpressionDescriptor.Test
{
    [TestFixture]
    public class TestExceptions
    {
        [Test]
        public void TestNullCronExpressionException()
        {
            Options options = new Options() { ThrowExceptionOnParseError = true };
            ExpressionDescriptor ceh = new ExpressionDescriptor(null, options);
            Assert.Throws<MissingFieldException>(() =>
            {
                ceh.GetDescription(DescriptionTypeEnum.FULL);
            });
        }

        [Test]
        public void TestEmptyCronExpressionException()
        {
            Options options = new Options() { ThrowExceptionOnParseError = true };
            ExpressionDescriptor ceh = new ExpressionDescriptor(null, options);
            Assert.Throws<MissingFieldException>(() =>
            {
                ceh.GetDescription(DescriptionTypeEnum.FULL);
            });  
        }

        [Test]
        public void TestNullCronExpressionError()
        {
            Options options = new Options() { ThrowExceptionOnParseError = false };
            ExpressionDescriptor ceh = new ExpressionDescriptor(null, options);
            Assert.AreEqual("Field 'expression' not found.", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [Test]
        public void TestInvalidCronExpressionException()
        {
            Options options = new Options() { ThrowExceptionOnParseError = true };
            ExpressionDescriptor ceh = new ExpressionDescriptor("INVALID", options);
            Assert.Throws<FormatException>(() =>
            {
                ceh.GetDescription(DescriptionTypeEnum.FULL);
            }); 
        }

        [Test]
        public void TestInvalidCronExpressionError()
        {
            Options options = new Options() { ThrowExceptionOnParseError = false };
            ExpressionDescriptor ceh = new ExpressionDescriptor("INVALID CRON", options);
            Assert.AreEqual("Error: Expression only has 2 parts.  At least 5 part are required.", ceh.GetDescription(DescriptionTypeEnum.FULL));
        }

        [Test]
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
