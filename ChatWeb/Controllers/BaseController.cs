using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UtilitiesChat.Models.WS;

namespace ChatWeb.Controllers;

public class BaseController : Controller
{
  public UserResponse oUserSession;

  public override void OnActionExecuting(ActionExecutingContext context)
  {
      oUserSession = JsonSerializer.Deserialize<UserResponse>(HttpContext.Session.GetString("User"));;
      base.OnActionExecuting(context);
  }
}