using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ChatWS.Models;

[Table("Message")]
public partial class Message
{
    [Key]
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdRoom { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Text { get; set; } = null!;

    public int IdState { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateCreated { get; set; }

    [ForeignKey("IdRoom")]
    public virtual Room IdRoomNavigation { get; set; } = null!;

    [ForeignKey("IdState")]
    public virtual CState IdStateNavigation { get; set; } = null!;

    [ForeignKey("IdUser")]
    public virtual User IdUserNavigation { get; set; } = null!;
}
