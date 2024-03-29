﻿using ChikovMF.Application.Common.Exceptions;
using ChikovMF.Application.Common.Interfaces;
using ChikovMF.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ChikovMF.Application.Features.Projects.EditProject;

public class EditProjectCommandHandler : IRequestHandler<EditProjectCommand, Guid>
{
    public async Task<Guid> Handle(EditProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects
            .Include(p => p.Links)
            .Include(p => p.TagLinks)
            .FirstOrDefaultAsync(p => p.ProjectId == request.ProjectId, cancellationToken);

        if (project == null)
        {
            throw new NotFoundEntityException(nameof(Project), request.ProjectId);
        }

        var pm = request.Project;

        project.Name = pm.Name;
        project.Description = pm.Description;
        project.Content = pm.Content;
        project.Links = pm.Links?.Select(l => new ProjectLink
        {
            Name = l.Name,
            Url = l.Url,
        }).ToList();

        if (pm.Tags != null)
        {
            project.TagLinks = pm.Tags.Select(tag => new ProjectTag
            {
                Order = tag.Order,
                TagId = tag.TagId
            }).ToList();
        }
        else
        {
            project.TagLinks = null;
        }

        await _context.SaveChangesAsync(cancellationToken);

        return project.ProjectId;
    }

    private readonly IChikovMFContext _context;

    public EditProjectCommandHandler(IChikovMFContext context)
    {
        _context = context;
    }
}
