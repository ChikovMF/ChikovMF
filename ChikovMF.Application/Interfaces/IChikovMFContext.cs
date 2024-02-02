using ChikovMF.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Application.Interfaces;

public interface IChikovMFContext
{
    DbSet<Project> Projects { get; set; }
    DbSet<Tag> Tags { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
