using ChikovMF.Application.Common.Exceptions;
using ChikovMF.Application.Common.Interfaces;
using ChikovMF.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Application.Features.Projects.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand>
    {
        public async Task Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _context.Projects
                .FirstOrDefaultAsync(p => p.ProjectId == request.ProjectId, cancellationToken);

            if (project == null)
            {
                throw new NotFoundEntityException(nameof(Project), request.ProjectId);
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync(cancellationToken);
        }

        private readonly IChikovMFContext _context;

        public DeleteProjectCommandHandler(IChikovMFContext context)
        {
            _context = context;
        }
    }
}
