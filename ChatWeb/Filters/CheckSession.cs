using ChatWeb.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChatWeb.Filters;

public class CheckSession : ActionFilterAttribute
{
  public override void OnActionExecuted(ActionExecutedContext context)
  {
    try
    {
      if (context.HttpContext.Session.GetString("User") == null)
      {
        if (context.Controller is HomeController == false)
        {
          context.HttpContext.Response.Redirect("Home/Login");  
        }
      }
      base.OnActionExecuted(context);
    }
    catch (Exception e)
    {

    }      
  }
}