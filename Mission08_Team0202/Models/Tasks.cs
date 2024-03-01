using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0202.Models;

public partial class Tasks
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TaskId { get; set; }

    public string Task { get; set; } = null!;

    public string? DueDate { get; set; }

    public int Quadrant { get; set; }

    // Navigation property to Categories
    [ForeignKey ("CategoryId")]
    public int? CategoryId { get; set; }
    public Categories? Category { get; set; }

    public bool Completed { get; set; }



}
