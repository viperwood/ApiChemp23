using System;
using System.Collections.Generic;

namespace Chempionat23Api.Models;

public partial class Compani
{
    public int Id { get; set; }

    public string Namecompani { get; set; } = null!;

    public string Adres { get; set; } = null!;

    public long Inn { get; set; }

    public long Pc { get; set; }

    public long Bick { get; set; }

    public DateTime? Datadrop { get; set; }

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
