using ChikovMF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChikovMF.Context.EntityConfigurations;

public class ProjectLinkConfiguration : IEntityTypeConfiguration<ProjectLink>
{
    public void Configure(EntityTypeBuilder<ProjectLink> builder)
    {
        builder.ToTable("ProjectLinks");
        builder.HasKey(project => project.ProjectLinkId);
    }
}
