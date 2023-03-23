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

  public Reply Execute<T>(string url, string method, T objectRequest)
  {
    oReply.result = 0;
    string result = "";

    try 
    {
      string js = JsonSerializer.Serialize(objectRequest);
      WebRequest request =  WebRequest.Create(url);

      request.Method = method;
      request.PreAuthenticate = true;
      request.ContentType = "application/json;charset=utf-8";
      request.Timeout = 1000;

      using (var oStreamWriter = new StreamWriter(request.GetRequestStream()))
      {
        oStreamWriter.Write(js);
        oStreamWriter.Flush();
      }

      var response = (HttpWebResponse)request.GetResponse();

      using(var oStreamWReader = new StreamReader(response.GetResponseStream()))
      {
        result = oStreamWReader.ReadToEnd();
      }

      oReply = JsonSerializer.Deserialize<Reply>(result);
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