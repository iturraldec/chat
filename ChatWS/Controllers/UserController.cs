using ChatWS.Data;
using ChatWS.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ChatWS.Controllers;

[ApiController]
public class UserController : ControllerBase
{
  [HttpGet]
  [Route("api/user/list")]
  public Reply Get()
  {
    using (ChatContext context = new ChatContext())
    {
      Reply oReplay = new Reply();
      oReplay.message = "Listado de usuarios.";
      oReplay.result = 1;
      oReplay.data = context.Users.ToList();
      return oReplay;
    }
  }
}