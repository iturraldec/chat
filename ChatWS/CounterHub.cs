using Microsoft.AspNet.SignalR;

namespace ChatWS;

public class CounterHub : Hub
{
    public override Task OnConnected()
    {
      Clients.All.enterUser();
      return base.OnConnected();
    }
}