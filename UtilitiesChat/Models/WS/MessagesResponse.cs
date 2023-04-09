namespace UtilitiesChat.Models.WS;

public class MessagesResponse
{
  public int id { get; set; }
  public string message { get; set; }
  public DateTime dateCreated { get; set; }
  public int idUser { get; set; }
  public string userName { get; set; }
  public int typeMessage { get; set; } // 1 propietario - 2 no propietario
}