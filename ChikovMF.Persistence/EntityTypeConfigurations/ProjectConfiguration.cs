﻿using ChikovMF.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChikovMF.Persistence.EntityTypeConfigurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(project => project.Title)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(project => project.ShortDescription)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(project => project.DetailedDescription)
            .IsRequired(false);
    }
}
