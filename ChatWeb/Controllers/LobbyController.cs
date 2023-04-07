using System.Text.Json;
using ChatWeb.Business;
using Microsoft.AspNetCore.Mvc;
using UtilitiesChat.Models.WS;
using UtilitiesChat.Tools;

namespace ChatWeb.Controllers;

public class LobbyController : BaseController
{
  public async Task<ActionResult> Index()
  {
    GetSession();
    List<ListRoomsResponse> lst = new List<ListRoomsResponse>();
    SecurityRequest oSecurityRequest = new SecurityRequest();
    oSecurityRequest.AccessToken = oUserSession.accessToken;

    RequestUtil oRequestUtil = new RequestUtil();
    UtilitiesChat.Models.WS.Reply oReply = await oRequestUtil.Execute<SecurityRequest>(Constants.ROOMS, "post", oSecurityRequest);
    lst = JsonSerializer.Deserialize<List<ListRoomsResponse>>(JsonSerializer.Serialize(oReply.data));

    return View(lst);
  }
}
