using Microsoft.AspNetCore.Mvc;

namespace ChatWeb.Controllers;

public class LobbyController : Controller
{
  private readonly ILogger<HomeController> _logger;
  public LobbyController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }

  public ActionResult Index()
  {
    return View();
  }
}
