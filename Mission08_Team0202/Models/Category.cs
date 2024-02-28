﻿using System;
using System.Collections.Generic;

namespace Mission08_Team0202.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Category1 { get; set; } = null!;

    // Navigation property back to Tasks
    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
