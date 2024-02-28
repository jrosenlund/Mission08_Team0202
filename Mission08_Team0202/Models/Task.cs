using System;
using System.Collections.Generic;

namespace Mission08_Team0202.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string Task1 { get; set; } = null!;

    public string? DueDate { get; set; }

    public int Quadrant { get; set; }

    public int? CategoryId { get; set; }

    public bool? Completed { get; set; }

    // Navigation property to Category
    public virtual Category? Category { get; set; }
}
