﻿// <auto-generated />
using System;
using ChikovMF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChikovMF.Context.Migrations
{
    [DbContext(typeof(ChikovMFContext))]
    [Migration("20240220230701_projectLink")]
    partial class projectLink
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChikovMF.Entities.AccessToken", b =>
                {
                    b.Property<Guid>("AccessTokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateOfReceiving")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("HashToken")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("AccessTokenId");

                    b.ToTable("AccessTokens");
                });

            modelBuilder.Entity("ChikovMF.Entities.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects", (string)null);
                });

            modelBuilder.Entity("ChikovMF.Entities.ProjectImage", b =>
                {
                    b.Property<Guid>("ProjectImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Alt")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ImageType")
                        .HasColumnType("integer");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("Src")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.HasKey("ProjectImageId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectImage");
                });

            modelBuilder.Entity("ChikovMF.Entities.ProjectLink", b =>
                {
                    b.Property<Guid>("ProjectLinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ProjectLinkId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectLinks", (string)null);
                });

            modelBuilder.Entity("ChikovMF.Entities.ProjectTag", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uuid");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.HasKey("ProjectId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("ProjectTag");
                });

            modelBuilder.Entity("ChikovMF.Entities.Tag", b =>
                {
                    b.Property<Guid>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.HasKey("TagId");

                    b.ToTable("Tags", (string)null);
                });

            modelBuilder.Entity("ChikovMF.Entities.ProjectImage", b =>
                {
                    b.HasOne("ChikovMF.Entities.Project", "Project")
                        .WithMany("Images")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ChikovMF.Entities.ProjectLink", b =>
                {
                    b.HasOne("ChikovMF.Entities.Project", "Project")
                        .WithMany("Links")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ChikovMF.Entities.ProjectTag", b =>
                {
                    b.HasOne("ChikovMF.Entities.Project", "Project")
                        .WithMany("TagLinks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChikovMF.Entities.Tag", "Tag")
                        .WithMany("ProjectLinks")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("ChikovMF.Entities.Project", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Links");

                    b.Navigation("TagLinks");
                });

            modelBuilder.Entity("ChikovMF.Entities.Tag", b =>
                {
                    b.Navigation("ProjectLinks");
                });
#pragma warning restore 612, 618
        }
    }
}
