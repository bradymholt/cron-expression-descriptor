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
            return Json(
                ExpressionDescriptor.GetDescription(expression, new Options()
                {
                    ThrowExceptionOnParseError = false,
                    Locale = (locale ?? "en-US")
                })
            );
        }
    }
}
