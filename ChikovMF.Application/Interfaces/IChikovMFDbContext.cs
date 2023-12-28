using ChikovMF.Domain;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Application.Interfaces;

public interface IChikovMFDbContext
{
    DbSet<Project> Projects { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
