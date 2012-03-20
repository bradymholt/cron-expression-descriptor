using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CronExpressionDescriptor
{
    public class Options
    {
        public Options()
        {
            this.ThrowExceptionOnParseError = false;
        }

        public bool ThrowExceptionOnParseError { get; set; }
    }
}
