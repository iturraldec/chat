using System;
using System.Collections.Generic;

namespace ChatWS.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int StateId { get; set; }

    public DateTime DateCreated { get; set; }

    public string Name { get; set; } = null!;

    public virtual CState State { get; set; } = null!;
}
