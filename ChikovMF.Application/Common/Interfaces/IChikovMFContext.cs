using ChikovMF.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Application.Common.Interfaces;

public interface IChikovMFContext
{
    DbSet<Project> Projects { get; set; }
    DbSet<Tag> Tags { get; set; }
    DbSet<AccessToken> AccessTokens { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
