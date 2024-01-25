using System;
using System.Collections.Generic;

namespace Chempionat23Api.Models;

public partial class Order
{
    public int Id { get; set; }

    public DateTime Datacreate { get; set; }

    public bool Statusorder { get; set; }

    public bool Statusservice { get; set; }

    public int? Servicesid { get; set; }

    public DateTime? Timecompletion { get; set; }

    public int Worcer { get; set; }

    public int Deviceid { get; set; }

    public int Scoreid { get; set; }

    public DateTime? Datadivicestart { get; set; }

    public TimeOnly? Timeworckdivise { get; set; }

    public DateTime? Datadrop { get; set; }

    public virtual Divice Device { get; set; } = null!;

    public virtual Score Score { get; set; } = null!;

    public virtual Service? Services { get; set; }

    public virtual Laborant WorcerNavigation { get; set; } = null!;
}
