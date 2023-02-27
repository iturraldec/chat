using System;
using System.Collections.Generic;

namespace ChatWS.Models;

public partial class CState
{
    public int StateId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; } = new List<User>();
}
