using Microsoft.EntityFrameworkCore;
using Taboo.Entities;

namespace Taboo.DAL;

public class TabooDbContext :DbContext
{
    public DbSet<Language> Languages { get; set; }
    public TabooDbContext(DbContextOptions opt) : base(opt)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>(model =>
        {
            model.HasKey(x => x.Code);

            model.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(2);

            model.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(64);

            model.Property(x => x.Icon)
            .IsRequired()
            .HasMaxLength(128);
        });
        base.OnModelCreating(modelBuilder);
    }
}
