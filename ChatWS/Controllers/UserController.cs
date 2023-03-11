using Microsoft.AspNetCore.Mvc;
using ChatWS.Data;
using ChatWS.Dto;

namespace ChatWS.Controllers;

[ApiController]
public class UserController : ControllerBase
{
  [HttpGet]
  [Route("api/user/list")]
  public Reply List()
  {
    Reply oReply = new Reply();
    using (ChatContext context = new ChatContext())
    {
      oReply.message = "Listado de usuarios.";
      oReply.result = 1;
      oReply.data = context.Users.ToList();
    }
    return oReply;
  }
  
  [HttpPost]
  [Route("api/user/register")]
  public Reply Register([FromBody] ChatWS.Models.Request.User userRequest)
  {
    Reply oReply = new Reply();
    
    try
    {
      using (ChatContext context = new ChatContext())
      {
        ChatWS.Models.User oUser = new ChatWS.Models.User();
        oUser.Email = userRequest.Email;
        oUser.Name = userRequest.Name;
        oUser.Password = userRequest.Password;

        context.Users.Add(oUser);
        context.SaveChanges();

        oReply.result = 1;
      }
    }
    catch(Exception e)
    {
      oReply.result = 0;
      oReply.message = "Intenta nuevamente mas tarde...";

      //log
    }

    return oReply;
  }
}