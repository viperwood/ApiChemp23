using System;
using System.Collections.Generic;

namespace Chempionat23Api.Models;

public partial class Histori
{
    public int Id { get; set; }

    public DateTime Datahistori { get; set; }

    public int? Userid { get; set; }

    public DateTime? Datadrop { get; set; }

    public bool Connectuser { get; set; }

    public virtual User? User { get; set; }
}
