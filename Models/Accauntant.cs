using System;
using System.Collections.Generic;

namespace Chempionat23Api.Models;

public partial class Accauntant
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public int Servicesaccauntid { get; set; }

    public DateTime? Datadrop { get; set; }

    public virtual ICollection<Score> Scores { get; set; } = new List<Score>();

    public virtual Servicesaccaun Servicesaccaunt { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
