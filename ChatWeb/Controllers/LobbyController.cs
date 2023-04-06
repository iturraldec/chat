using Microsoft.AspNetCore.Mvc;
using UtilitiesChat.Models.WS;

namespace ChatWeb.Controllers;

public class LobbyController : BaseController
{
  public LobbyController()
  {
  }

  public ActionResult Index()
  {
    List<ListRoomsResponse> lst = new List<ListRoomsResponse>();

    ViewBag.misesion = oUserSession.accessToken;
    return View(lst);
  }
}
