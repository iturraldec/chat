using Microsoft.AspNetCore.Mvc;

namespace ChatWeb.Controllers;

public class LobbyController : Controller
{
  public LobbyController()
  {
  }

  public ActionResult Index()
  {
    return View();
  }
}
