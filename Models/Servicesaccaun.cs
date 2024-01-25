using System;
using System.Collections.Generic;

namespace Chempionat23Api.Models;

public partial class Servicesaccaun
{
    public int Id { get; set; }

    public string Nameservices { get; set; } = null!;

    public DateTime? Datadrop { get; set; }

    public virtual ICollection<Accauntant> Accauntants { get; set; } = new List<Accauntant>();
}
