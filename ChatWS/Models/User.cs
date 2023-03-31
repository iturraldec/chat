using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChatWS.Models;

[Table("User")]
[Index("Email", Name = "User_UN", IsUnique = true)]
public partial class User
{
    [Key]
    public int UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [StringLength(64)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DateCreated { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    public int StateId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AccessToken { get; set; }

    [ForeignKey("StateId")]
    [InverseProperty("Users")]
    public virtual CState State { get; set; } = null!;
}
