using ChikovMF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChikovMF.Context.EntityConfigurations;

public class ProjectTagConfiguration : IEntityTypeConfiguration<ProjectTag>
{
    public void Configure(EntityTypeBuilder<ProjectTag> builder)
    {
        builder.HasKey(projectTag => new {projectTag.ProjectId, projectTag.TagId});
    }
}
