using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Taboo.Entities;

namespace Taboo.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            
                builder.HasKey(x => x.Code);

                builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(2);

                builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(64);

                builder.Property(x => x.Icon)
                .IsRequired()
                .HasMaxLength(128);
            builder.HasData(new Language
            {
                Code = "AZ",
                Icon = "https://upload.wikimedia.org/wikipedia/commons/3/3d/AZ-Azerbaijan-Flag-icon.png",
                Name = "Azərbaycan"
            },
            new Language
            {
                Code = "EN",
                Icon = "https://cdn-icons-png.flaticon.com/512/5111/5111640.png",
                Name = "English"
            },
            new Language
            {
                Code = "RU",
                Icon = "https://icons.iconarchive.com/icons/custom-icon-design/flat-europe-flag/256/Russia-icon.png",
                Name = "Русский"
            });
           
        }
    }
}
