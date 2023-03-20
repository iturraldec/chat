using System.Text.Json;
using UtilitiesChat.Models.WS;

namespace UtilitiesChat.Tools;

public class RequestUtil
{
  private static HttpClient _client  = new HttpClient();
  public Reply oReply {get; set;}

  public RequestUtil()
  {
    _client.Timeout = TimeSpan.FromMinutes(1);
    oReply = new Reply();
  }

  /*public async Task<Reply> Get(string url)
  {
    try 
    {
      oReply = await JsonSerializer.DeserializeAsync<Reply>(_client.GetStringAsync(url));
    }
    catch (Exception e) 
    {
      oReply.result = 0;
      oReply.message = "Error: Ocurrio un error inesperado.";
    }
    return oReply;
  }*/

  public Reply Execute<T>(string url, string method, T objectRequest)
  {
    try 
    {
      switch(method)
      {
        case "post":
          var data = JsonSerializer.Serialize<T>(objectRequest);
          HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");

          oReply.data = _client.PostAsync(url, content);
          oReply.result = 1;
          break;
      }
    }
    catch (Exception e) 
    {
      oReply.result = 0;
      oReply.message = "Error: Ocurrio un error inesperado.";
    }
    return oReply;
  }
}