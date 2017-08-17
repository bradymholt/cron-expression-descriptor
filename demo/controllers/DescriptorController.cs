using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CronExpressionDescriptor.Demo.Controllers
{
    [Route("api/[controller]")]
    public class DescriptorController : Controller
    {
        [HttpGet]
        public JsonResult Get(string expression, string locale)
        {
            var result = ExpressionDescriptor.GetDescription(expression, new Options()
            {
                ThrowExceptionOnParseError = false,
                Verbose = false,
                DayOfWeekStartIndexZero = true,
                Locale = (locale ?? "en-US")
            });

            return Json(new { description = result });
        }
    }
}
