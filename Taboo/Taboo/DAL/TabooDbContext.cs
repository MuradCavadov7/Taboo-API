using Microsoft.EntityFrameworkCore;
using Taboo.Entities;

namespace Taboo.DAL;

public class TabooDbContext :DbContext
{

    public DbSet<Language> Languages { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Word> Words { get; set; }
    public DbSet<BannedWord> BannedWords { get; set; }
    public TabooDbContext(DbContextOptions opt) : base(opt)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TabooDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
