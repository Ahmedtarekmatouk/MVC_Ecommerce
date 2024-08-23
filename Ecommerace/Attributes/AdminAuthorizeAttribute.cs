using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Ecommerace.Attributes;

public class AdminAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        var returnUrl = context.HttpContext.Request.Path;

        if (!user.Identity.IsAuthenticated || !user.IsInRole("Admin"))
        { 
            context.Result = new RedirectResult($"/admin/auth/Login");
        }
    }
}