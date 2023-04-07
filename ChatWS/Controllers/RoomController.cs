using Microsoft.AspNetCore.Mvc;
using UtilitiesChat.Models.WS;

namespace ChatWS.Controllers;

public class RoomController : BaseController
{
  [HttpPost]
  [Route("api/room")]
  public Reply List([FromBody] SecurityRequest model)
  {
    Reply oR = new Reply();

    if(!VerifyToken(model))
    {
      oR.result = 0;
      oR.message = "Mètodo restringido.";
      return oR;
    }

    using(Data.ChatContext db = new Data.ChatContext())
    {
      List<ListRoomsResponse> listRoomsResponse = (from d in db.Rooms
                                                where d.IdState == 1
                                                orderby d.Name
                                                select new ListRoomsResponse {
                                                  id = d.Id,
                                                  name = d.Name,
                                                  description = d.Description
                                                }).ToList();
      oR.result = 1;
      oR.data = listRoomsResponse;
    }

    return oR;
  }
}