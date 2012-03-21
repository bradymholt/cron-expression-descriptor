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
            this.ThrowExceptionOnParseError = true;
            this.CasingType = CasingTypeEnum.Sentence;
        }

        public bool ThrowExceptionOnParseError { get; set; }
        public CasingTypeEnum CasingType { get; set; }
    }
}
