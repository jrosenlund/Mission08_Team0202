using System;
using System.Collections.Generic;

namespace Mission08_Team0202.Models;

public partial class Categories
{
    public int CategoryId { get; set; }

    public string Category { get; set; } = null!;

    // Navigation property back to Tasks
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
