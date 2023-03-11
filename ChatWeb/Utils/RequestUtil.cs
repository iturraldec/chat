using ChatWeb.Dto;
using System.Text.Json;

namespace ChatWeb.Utils;

public class RequestUtil
{
  private static HttpClient _client  = new HttpClient();
  public Reply oReply {get; set;}

  public RequestUtil()
  {
    _client.Timeout = TimeSpan.FromMinutes(1);
    oReply = new Reply();
  }

  public async Task<Reply> Execute<T>(string url, string method, T objectRequest)
  {
    try 
    {
      var data = JsonSerializer.Serialize<T>(objectRequest);
      HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
      oReply.data = await _client.PostAsync(url, content);
      oReply.result = 1;
    }
    catch (Exception e) 
    {
      oReply.result = 0;
      oReply.message = "Error: Ocurrio un error inesperado.";
    }
    return oReply;
  }
}