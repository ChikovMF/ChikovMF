using ChikovMF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChikovMF.Context.EntityConfigurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects");
        builder.HasKey(project => project.ProjectId);
        builder.Property(project => project.Name).HasMaxLength(64).IsRequired();
        builder.Property(project => project.Description).HasMaxLength(255).IsRequired();
    }
}
