using System.Web;
using System.Web.Mvc;

public class EmailSessionAuthorizationAttribute : AuthorizeAttribute
{
    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        // Check if the email session is available
        return !string.IsNullOrEmpty(httpContext.Session["userEmail"] as string);
    }

    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
        // Redirect to the login page if unauthorized
        filterContext.Result = new RedirectResult("~/Users/Login");
    }
}
