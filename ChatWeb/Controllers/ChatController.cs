using System.Text.Json;
using ChatWeb.Business;
using Microsoft.AspNetCore.Mvc;
using UtilitiesChat.Models.WS;
using UtilitiesChat.Tools;

namespace ChatWeb.Controllers;

public class ChatController : BaseController
{
  public async Task<ActionResult> Messages(int id)
  {
    GetSession();
    List<MessagesResponse> lst = new List<MessagesResponse>();
    MessagesRequest oMessagesRequest = new MessagesRequest();
    RequestUtil oRequestUtil = new RequestUtil();
    
    oMessagesRequest.AccessToken = oUserSession.accessToken;
    oMessagesRequest.IdRoom = id;

    Reply oReply = await oRequestUtil.Execute<MessagesRequest>(Constants.MESSAGES, "post", oMessagesRequest);

    var oData = new {
      oUserSession = oUserSession,
      idRoom = id,
      lstMessages = JsonSerializer.Deserialize<List<MessagesResponse>>(JsonSerializer.Serialize(oReply.data))
    };

    return View(oData);
  }
}