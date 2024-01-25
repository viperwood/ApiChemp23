using System;
using System.Collections.Generic;

namespace Chempionat23Api.Models;

public partial class Score
{
    public int Id { get; set; }

    public int Accauntentid { get; set; }

    public int Companiid { get; set; }

    public decimal? Costscore { get; set; }

    public DateTime? Datadrop { get; set; }

    public virtual Accauntant Accauntent { get; set; } = null!;

    public virtual Compani Compani { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
