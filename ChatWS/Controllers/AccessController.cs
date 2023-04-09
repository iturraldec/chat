using Microsoft.AspNetCore.Mvc;
using ChatWS.Data;
using UtilitiesChat.Models.WS;
using Microsoft.EntityFrameworkCore;

namespace ChatWS.Controllers;

[ApiController]
public class AccessController : ControllerBase
{
  [HttpPost]
  [Route("api/access")]
  public Reply Login([FromBody] AccessRequest model)
  {
    Reply oReply = new Reply();

    oReply.result = 0;
    
    using(ChatContext db = new ChatContext())
    {
        var oUser = (from d in db.Users
                    where d.Email == model.Email && d.Password == model.Password
                    select d).FirstOrDefault();
        
        if(oUser != null)
        {
            UserResponse oUserResponse = new UserResponse();
            string accessToken = Guid.NewGuid().ToString();

            oUser.AccessToken = accessToken;
            db.Entry(oUser).State = EntityState.Modified;
            db.SaveChanges();

            oUserResponse.id = oUser.UserId;
            oUserResponse.email = oUser.Email;
            oUserResponse.name = oUser.Name;
            oUserResponse.accessToken = accessToken;

            oReply.result = 1;
            oReply.data = oUserResponse;
        }
        else
        {
            oReply.message = "Datos incorrectos";
        }
    }

    return oReply;
  }
}