using Microsoft.AspNetCore.Mvc;
using ChatWeb.Business;
using UtilitiesChat.Tools;
using ChatWeb.Models.ViewModels;
using UtilitiesChat.Models.WS;
using System.Text.Json;

namespace ChatWeb.Controllers;

public class HomeController : Controller
{
  public HomeController()
  {
  }

  [HttpGet]
  public ActionResult Login()
  {
    UserAccessViewModel model = new UserAccessViewModel();

    return View(model);
  }

  [HttpPost]
  public async Task<ActionResult> Login(UserAccessViewModel model)
  {
    if(!ModelState.IsValid)
    {
      return View(model);
    }

    RequestUtil oRequestUtil = new RequestUtil();
    AccessRequest oAR = new AccessRequest();

    oAR.Email = model.Email;
    oAR.Password = UtilitiesChat.Tools.Encrypt.GetSha256(model.Password);
    UtilitiesChat.Models.WS.Reply oReply = await oRequestUtil.Execute<AccessRequest>(Constants.ACCESS, "post", oAR);
    if(oReply.result == 1)
    {
      HttpContext.Session.SetString("User", JsonSerializer.Serialize(oReply.data));
      return RedirectToAction("Index", "Lobby");
    }
    
    ViewBag.error = "Datos incorrectos!";
    return View(model);
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
    if(!ModelState.IsValid)
    {
      return View(model);
    }

    Models.Request.User oUser = new Models.Request.User();

    oUser.Name = model.Name;
    oUser.Email = model.Email;
    oUser.Password = model.Password;

    RequestUtil oRequestUtil = new RequestUtil();
    //UtilitiesChat.Models.WS.Reply oReply = oRequestUtil.Execute<Models.Request.User>(Constants.REGISTER, "post", oUser);

    return View();
  }
}
