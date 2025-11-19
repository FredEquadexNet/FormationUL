using System;
using System.Collections.Generic;

namespace Services.DataAccessLayer;

public partial class Step
{
    public int Id { get; set; }

    public short Order { get; set; }

    public string Description { get; set; } = null!;

    public Guid RecipeId { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;
}
