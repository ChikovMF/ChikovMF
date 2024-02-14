using ChikovMF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChikovMF.Context.EntityConfigurations;

public class ProjectImageConfiguration : IEntityTypeConfiguration<ProjectImage>
{
    public void Configure(EntityTypeBuilder<ProjectImage> builder)
    {
        builder.HasKey(image => image.ProjectImageId);
        builder.Property(image => image.Alt).HasMaxLength(128).IsRequired();
        builder.Property(image => image.Src).HasMaxLength(128).IsRequired();
    }
}
