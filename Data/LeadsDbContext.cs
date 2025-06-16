using LeadsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LeadsAPI.Data;

public partial class LeadsDbContext : DbContext
{
    public LeadsDbContext()
    {
    }

    public LeadsDbContext(DbContextOptions<LeadsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LeadsInput> LeadsInputs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LeadsInput>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LeadsInp__3214EC07146D1DF9");

            entity.Property(e => e.Industry).HasMaxLength(100);
            entity.Property(e => e.Region).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
