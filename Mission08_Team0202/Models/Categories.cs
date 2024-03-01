using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0202.Models;

public partial class Categories
{
    [Key]
    public int CategoryId { get; set; }

    public string Category { get; set; } = null!;

    // Navigation property back to Task
    public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
}
