namespace UtilitiesChat.Models.WS;

public class UserResponse
{
  public int id { get; set; }
  public string name {get;set;} = null!;
  public string email {get;set;} = null!;
  public string accessToken {get; set;} = null!;
}