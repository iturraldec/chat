namespace ChatWS.Models;

public partial class CStateModel
{
    public int StateId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UserModel> Users { get; } = new List<UserModel>();
}
