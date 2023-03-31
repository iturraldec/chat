using Microsoft.AspNetCore.SignalR;

namespace ChatWS.Hubs;

public class CounterHub : Hub
{
    public async Task Send()
    {
      await Clients.All.SendAsync("EnterUser");
    }
}