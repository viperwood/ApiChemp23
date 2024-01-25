using System;
using System.Collections.Generic;

namespace Chempionat23Api.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Namerole { get; set; } = null!;

    public DateTime? Datadrop { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
