using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChatWS.Models;

[Table("cState")]
[Index("Name", Name = "cState_UN", IsUnique = true)]
public partial class CState
{
    [Key]
    public int StateId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("IdStateNavigation")]
    public virtual ICollection<Room> Rooms { get; } = new List<Room>();

    [InverseProperty("State")]
    public virtual ICollection<User> Users { get; } = new List<User>();
}
