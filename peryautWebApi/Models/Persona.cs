using System;
using System.Collections.Generic;

namespace peryautWebApi.Models;

public partial class Persona
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public bool Vivo { get; set; }

    public virtual ICollection<DueniosConAuto> DueniosConAutos { get; set; } = new List<DueniosConAuto>();
}
