using Microsoft.AspNetCore.Mvc;
using ChatWeb.Business;
using UtilitiesChat.Tools;

namespace ChatWeb.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;
  public HomeController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }

  public ActionResult Index()
  {
    return View();
  }

  [HttpGet]
  public ActionResult Register()
  {
    ChatWeb.Models.ViewModels.RegisterViewModel model = new ChatWeb.Models.ViewModels.RegisterViewModel();
    return View(model);
  }

  [HttpPost]
  public ActionResult Register(ChatWeb.Models.ViewModels.RegisterViewModel model)
  {
    Models.Request.User oUser = new Models.Request.User();

    oUser.Name = model.Name;
    oUser.Email = model.Email;
    oUser.Password = model.Password;

    RequestUtil oRequestUtil = new RequestUtil();
    UtilitiesChat.Models.WS.Reply oReply = oRequestUtil.Execute<Models.Request.User>(Constants.REGISTER, "post", oUser);
    return View();
  }
}
