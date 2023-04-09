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
    public async Task SendMessage(int idRoom, int idUser, string userName, string message)
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
      }

      await Clients.All.SendAsync("ReceiveMessage", idUser, userName, message, fecha);
    }
}