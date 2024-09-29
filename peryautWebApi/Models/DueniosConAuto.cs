using System;
using System.Collections.Generic;

namespace peryautWebApi.Models;

public partial class DueniosConAuto
{
    public Guid Id { get; set; }

    public Guid IdDuenio { get; set; }

    public Guid IdAuto { get; set; }

    public DateOnly Fecha { get; set; }

    public virtual Auto IdAutoNavigation { get; set; } = null!;

    public virtual Persona IdDuenioNavigation { get; set; } = null!;
}
