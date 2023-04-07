using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using UtilitiesChat.Models.WS;

namespace ChatWeb.Controllers;

public class BaseController : Controller
{
  public UserResponse oUserSession;

  public void GetSession()
  {
      oUserSession = JsonSerializer.Deserialize<UserResponse>(HttpContext.Session.GetString("User"));
  }
}