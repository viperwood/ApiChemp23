using System;
using System.Collections.Generic;

namespace Chempionat23Api.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Passworduser { get; set; } = null!;

    public string Fio { get; set; } = null!;

    public DateTime Birthday { get; set; }

    public int Spasport { get; set; }

    public int Npasport { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int Companiid { get; set; }

    public int Roleuser { get; set; }

    public DateTime? Datadrop { get; set; }

    public string? Ip { get; set; }

    public DateTime Lastenter { get; set; }

    public virtual ICollection<Accauntant> Accauntants { get; set; } = new List<Accauntant>();

    public virtual Compani Compani { get; set; } = null!;

    public virtual ICollection<Histori> Historis { get; set; } = new List<Histori>();

    public virtual ICollection<Laborant> Laborants { get; set; } = new List<Laborant>();

    public virtual Role RoleuserNavigation { get; set; } = null!;
}
