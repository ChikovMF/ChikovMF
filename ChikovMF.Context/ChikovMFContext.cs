using System.Reflection;
using ChikovMF.Application.Common.Interfaces;
using ChikovMF.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Context;

public class ChikovMFContext : DbContext, IChikovMFContext
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<AccessToken> AccessTokens { get; set; }

    public ChikovMFContext(DbContextOptions<ChikovMFContext> options)
        : base(options) => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(modelBuilder);
    }
}
