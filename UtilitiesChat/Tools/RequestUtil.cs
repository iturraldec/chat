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

  public async Task<Reply> Get(string url)
  {
    try 
    {
      oReply = JsonSerializer.Deserialize<Reply>(await _client.GetStringAsync(url));
    }
    catch (Exception e) 
    {
      oReply.result = 0;
      oReply.message = "Error: Ocurrio un error inesperado.";
    }
    return oReply;
  }

  /*public async Task<Reply> Execute<T>(string url, string method, T objectRequest)
  {
    try 
    {
      var data = JsonSerializer.Serialize<T>(objectRequest);
      HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
      //oReply.data = await _client.PostAsync(url, content);
      oReply.result = 1;
    }
    catch (Exception e) 
    {
      oReply.result = 0;
      oReply.message = "Error: Ocurrio un error inesperado.";
    }
    return oReply;
  }*/
}