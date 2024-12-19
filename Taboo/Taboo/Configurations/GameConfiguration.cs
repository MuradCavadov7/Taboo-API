using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taboo.Entities;

namespace Taboo.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {

            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Language)
                .WithMany(x => x.Games)
                .HasForeignKey(x => x.LanguageCode);
        }

    }
}
