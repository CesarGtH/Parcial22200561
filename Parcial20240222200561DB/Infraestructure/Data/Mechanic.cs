using System;
using System.Collections.Generic;

namespace Parcial20240222200561DB.Infraestructure.Data;

public partial class Mechanic
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public DateOnly HireDate { get; set; }
}
