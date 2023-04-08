using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChatWS.Models;

[Table("Room")]
public partial class Room
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime DateCreated { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    public int IdState { get; set; }

    [ForeignKey("IdState")]
    [InverseProperty("Rooms")]
    public virtual CState IdStateNavigation { get; set; } = null!;
}
