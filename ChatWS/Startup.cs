using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(ChatWS.Startup))]

namespace ChatWS;

public class Startup
{
  public void Configuration(IAppBuilder app)
  {
    app.Map("/signalr", map => {
      var hubConfiguration = new HubConfiguration {};

      map.UseCors(CorsOptions.AllowAll);
      map.RunSignalR(hubConfiguration);
    });
  }
}