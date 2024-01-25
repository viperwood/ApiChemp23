using System;
using System.Collections.Generic;

namespace Chempionat23Api.Models;

public partial class Divice
{
    public int Id { get; set; }

    public string Namedivices { get; set; } = null!;

    public DateTime? Datadrop { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
