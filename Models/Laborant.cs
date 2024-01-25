using System;
using System.Collections.Generic;

namespace Chempionat23Api.Models;

public partial class Laborant
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public int Serviceslabid { get; set; }

    public DateTime? Datadrop { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Serviceslab Serviceslab { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
