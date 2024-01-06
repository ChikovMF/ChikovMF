using ChikovMF.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChikovMF.Persistence.EntityTypeConfigurations;

public class ImageLinkConfigurations : IEntityTypeConfiguration<ImageLink>
{
    public void Configure(EntityTypeBuilder<ImageLink> builder)
    {
        builder.Property(imageLink => imageLink.Link)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(imageLink => imageLink.MainImage)
            .HasDefaultValue(false);
    }
}
