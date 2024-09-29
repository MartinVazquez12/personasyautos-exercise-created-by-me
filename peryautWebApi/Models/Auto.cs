using System;
using System.Collections.Generic;

namespace peryautWebApi.Models;

public partial class Auto
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Año { get; set; } = null!;

    public string Color { get; set; } = null!;

    public bool Activo { get; set; }

    public Guid IdMarca { get; set; }

    public virtual ICollection<DueniosConAuto> DueniosConAutos { get; set; } = new List<DueniosConAuto>();

    public virtual Marca IdMarcaNavigation { get; set; } = null!;
}
