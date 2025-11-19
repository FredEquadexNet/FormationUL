using System;
using System.Collections.Generic;

namespace Services.DataAccessLayer;

public partial class Recipe
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Step> Steps { get; set; } = new List<Step>();
}
