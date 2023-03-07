namespace ChatWS.Models;

public partial class UserModel
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int StateId { get; set; }

    public DateTime DateCreated { get; set; }

    public string Name { get; set; } = null!;

    public virtual CStateModel State { get; set; } = null!;
}
