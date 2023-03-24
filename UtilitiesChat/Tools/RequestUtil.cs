using System.Net;
using System.Text.Json;
using UtilitiesChat.Models.WS;

namespace UtilitiesChat.Tools;

public class RequestUtil
{
  public Reply oReply {get; set;}
  public RequestUtil()
  {
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

  public async Task<Reply> Execute<T>(string url, string method, T objectRequest)
  {
    oReply.result = 0;

    try 
    {
      var client = new HttpClient();

      client.Timeout = TimeSpan.FromMinutes(1);
      switch(method)
      {
        case "post":
          var data = JsonSerializer.Serialize<T>(objectRequest);
          HttpContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
          var response = await client.PostAsync(url, content);

          if(response.IsSuccessStatusCode)
          {
              var result = await response.Content.ReadAsStreamAsync();
              oReply = JsonSerializer.Deserialize<Reply>(result);
          }
          break;
      }
    }
    catch(TimeoutException e)
    {
      oReply.message = "Servidor sin respuesta";
    }
    catch (Exception e) 
    {
      oReply.message = "Error: Ocurrio un error inesperado.";
    }

    return oReply;
  }
}