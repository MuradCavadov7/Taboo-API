using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Taboo.Entities;

namespace Taboo.Configurations;

public class BannedWordConfiguration : IEntityTypeConfiguration<BannedWord>
{
    public void Configure(EntityTypeBuilder<BannedWord> builder)
    {

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Text)
        .IsRequired()
        .HasMaxLength(32);
    }
}
