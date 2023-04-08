using Microsoft.AspNetCore.Mvc;
using UtilitiesChat.Models.WS;

namespace ChatWS.Controllers;

public class BaseController : ControllerBase
{
  public UserResponse? oUserSession;
  protected bool VerifyToken(SecurityRequest model)
  {
    using(ChatWS.Data.ChatContext db = new ChatWS.Data.ChatContext())
    {
      var oUser = db.Users.Where(d => d.AccessToken == model.AccessToken).FirstOrDefault();

      if(oUser != null)
      {
        oUserSession = new UserResponse();

        oUserSession.id = oUser.UserId;
        oUserSession.accessToken = oUser.AccessToken;
        oUserSession.name = oUser.Name;
        oUserSession.email = oUser.Email;

        return true;
      }
    }

    return false;
  }
}