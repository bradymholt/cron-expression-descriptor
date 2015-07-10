using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CronExpressionDescriptor.Test
{
    public class Utilities
    {
        public static bool IsRunningOnMono(){
            return Type.GetType("Mono.Runtime") != null;
        }
    }
}
