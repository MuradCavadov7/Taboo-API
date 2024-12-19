using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taboo.Entities;

namespace Taboo.Configurations
{
    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Text)
            .IsRequired()
            .HasMaxLength(32);

            builder.HasMany(x => x.BannedWords)
                   .WithOne(x => x.Word)
                   .HasForeignKey(x => x.WordId);

            builder.HasOne(x => x.Language)
                .WithMany(x => x.Words)
                .HasForeignKey(x => x.LanguageCode);
        }
    }
}
