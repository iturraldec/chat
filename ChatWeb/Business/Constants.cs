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
}