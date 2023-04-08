using ChatWS.Data;
using Microsoft.AspNetCore.Mvc;
using UtilitiesChat.Models.WS;

namespace ChatWS.Controllers;

public class MessageController : BaseController
{
  [HttpPost]
  [Route("api/message")]
  public Reply Get([FromBody] MessagesRequest model)
  {
    Reply oReply = new Reply();

    if(!VerifyToken(model))
    {
      oReply.result = 0;
      oReply.message = "Mètodo restringido.";
      return oReply;
    }

    try 
    {
      using(ChatContext db = new ChatContext())
      {
        List<MessagesResponse> lst = (from d in db.Messages.ToList()
                                      join usuario in db.Users
                                      on d.IdUser equals usuario.UserId
                                      where d.IdState == 1
                                      orderby d.DateCreated descending
                                      select new MessagesResponse
                                      {
                                        Id = d.Id,
                                        Message = d.Text,
                                        DateCreated = d.DateCreated,
                                        IdUser = d.IdUser,
                                        UserName = usuario.Name,
                                        TypeMessage = (
                                          new Func<int>(() => {
                                            try
                                            {
                                              if(d.IdUser == oUserSession.id)
                                                return 1;
                                              else
                                                return 2;
                                            }
                                            catch
                                            {
                                              return 2;
                                            }
                                          })
                                        )()
                                      }
                                      ).Take(20).ToList();

        oReply.result = 1;
        oReply.data = lst;
      }
    }
    catch(Exception e)
    {
      oReply.message = "Ocurrio un error al cargar los mensajes.";
      oReply.result = 0;
    }
    return oReply;
  }
}