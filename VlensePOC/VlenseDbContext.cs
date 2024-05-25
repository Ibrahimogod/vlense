using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VlensePOC.Modes;

namespace VlensePOC;

public class VlenseDbContext(DbContextOptions<VlenseDbContext> options) : DbContext(options)
{
    public DbSet<Step> Steps { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Step>()
            .Property(s => s.StepType)
            .HasConversion<EnumToStringConverter<StepType>>();
    }
}