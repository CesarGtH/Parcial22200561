using System;
using System.Collections.Generic;

namespace Parcial20240222200561DB.Infraestructure.Data;

public partial class AutoParts
{
    public int Id { get; set; }

    public string PartName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }
}
