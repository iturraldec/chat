using ChatWS.Data;
using ChatWS.Models;
using Microsoft.AspNetCore.SignalR;

namespace ChatWS.Hubs;

public class ChatHub : Hub
{
    public override Task OnConnectedAsync()
    {
      Clients.All.SendAsync("EnterUser");
      return base.OnConnectedAsync();
    }

    public Task AddGroup(string idRoom)
    {
      return Groups.AddToGroupAsync(Context.ConnectionId, idRoom);
    }

    public async Task SendMessage(int idRoom, int idUser, string userName, string message, string accessToken)
    {
      if(VerifyToken(accessToken))
      {
        string fecha = DateTime.Now.ToString();

        using(ChatContext db = new ChatContext())
        {
          var oMessage = new Message();

          oMessage.IdRoom = idRoom;
          oMessage.IdUser = idUser;
          oMessage.Text = message;
          oMessage.DateCreated = DateTime.Now;
          oMessage.IdState = 1;

          db.Messages.Add(oMessage);
          db.SaveChanges();
          
          await Clients.Group(idRoom.ToString()).SendAsync("ReceiveMessage", oMessage.Id, idUser, userName, message, fecha); 
        }
      }
    }

  protected bool VerifyToken(string accessToken)
  {
    using(ChatWS.Data.ChatContext db = new ChatWS.Data.ChatContext())
    {
      var oUser = db.Users.Where(d => d.AccessToken == accessToken).FirstOrDefault();

      return (oUser != null);
    }
  }
}