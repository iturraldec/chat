using ChatWS.Data;
using ChatWS.Dto;
using Microsoft.AspNetCore.Mvc;
using ChatWS.Models;
using ChatWS.Models.Request;

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
  public Reply Register([FromBody] User model)
  {
    Reply oReply = new Reply();
    
    try
    {
      using (ChatContext context = new ChatContext())
      {
        UserModel oUser = new UserModel();
        oUser.Email = model.Email;
        oUser.Name = model.Name;
        oUser.Password = model.Password;

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