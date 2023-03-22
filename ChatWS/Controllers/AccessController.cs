using Microsoft.AspNetCore.Mvc;
using ChatWS.Data;
using UtilitiesChat.Models.WS;
using Microsoft.EntityFrameworkCore;

namespace ChatWS.Controllers;

[ApiController]
public class AccessController : ControllerBase
{
  [HttpPost]
  [Route("api/user/login")]
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
            string accessToken = Guid.NewGuid().ToString();

            oUser.AccessToken = accessToken;
            db.Entry(oUser).State = EntityState.Modified;
            db.SaveChanges();
            oReply.result = 1;
            oReply.data = accessToken;
        }
        else
        {
            oReply.message = "Datos incorrectos";
        }
    }

    return oReply;
  }
}