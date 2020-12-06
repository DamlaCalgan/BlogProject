using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamlaProje.Blog.WebApi.CustomFilters
{
    public class ValildModel : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
                context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
}
