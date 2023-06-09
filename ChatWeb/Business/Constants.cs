namespace ChatWeb.Business;

public class Constants
{
  public static string URL_API
  {
    get
    {
      return "http://localhost:5133/";
    }
  }
  public static string LIST
  {
    get
    {
      return URL_API + "api/user/list/";
    }
    
  }

  public static string REGISTER
  {
    get
    {
      return URL_API + "api/user/register/";
    }
    
  }

  public static string ACCESS
  {
    get
    {
      return URL_API + "api/access/";
    }
  }

  public static string ROOMS
  {
    get
    {
      return URL_API + "api/room/";
    }
  }

  public static string MESSAGES
  {
    get
    {
      return URL_API + "api/message/";
    }
  }

  public static string SignalR
  {
    get
    {
      return URL_API + "chatHub/";
    }
  }
}