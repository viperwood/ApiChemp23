using System;
using System.Collections.Generic;

namespace Chempionat23Api.Models;

public partial class Service
{
    public int Id { get; set; }

    public string Nameservices { get; set; } = null!;

    public decimal Costsevices { get; set; }

    public TimeOnly Periodexecut { get; set; }

    public TimeOnly Averagedeviation { get; set; }

    public DateTime? Datadrop { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
