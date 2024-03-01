using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0202.Models;

public partial class TaskContext : DbContext
{
    public TaskContext()
    {
    }

    public TaskContext(DbContextOptions<TaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categories> Categories { get; set; }

    public virtual DbSet<Tasks> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // The warning directive can be removed as we are no longer hardcoding the connection string
            optionsBuilder.UseSqlite("Name=TaskConnection");
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categories>(entity =>
        {
            entity.Property(e => e.Category).HasColumnName("Category");
        });

        modelBuilder.Entity<Tasks>(entity =>
        {
            entity.Property(e => e.TaskId).ValueGeneratedOnAdd();
            entity.Property(e => e.Task).HasColumnName("Task");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
