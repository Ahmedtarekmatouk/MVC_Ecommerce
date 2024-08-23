using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerace.Attributes;

public class StoreAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        if (!user.Identity.IsAuthenticated || !user.IsInRole("Store"))
        {
            var returnUrl = context.HttpContext.Request.Path;
            context.Result = new RedirectResult($"/store/account/Login");
        }
    }
}
