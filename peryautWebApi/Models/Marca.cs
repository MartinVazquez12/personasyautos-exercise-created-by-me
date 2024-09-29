using System;
using System.Collections.Generic;

namespace peryautWebApi.Models;

public partial class Marca
{
    public Guid Id { get; set; }

    public string Marca1 { get; set; } = null!;

    public virtual ICollection<Auto> Autos { get; set; } = new List<Auto>();
}
