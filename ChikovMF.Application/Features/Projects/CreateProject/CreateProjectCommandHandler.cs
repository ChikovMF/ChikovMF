﻿using AutoMapper;
using ChikovMF.Application.Common.Interfaces;
using ChikovMF.Entities;
using MediatR;

namespace ChikovMF.Application.Features.Projects.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Guid>
{
    public async Task<Guid> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        Project project = _mapper.Map<Project>(request.Project);

        _context.Projects.Add(project);

        int changes = await _context.SaveChangesAsync(cancellationToken);

        if (changes > 0)
        {
            return project.ProjectId;
        }
        else
        {
            return Guid.Empty;
        }
    }

    private readonly IChikovMFContext _context;
    private readonly IMapper _mapper;

    public CreateProjectCommandHandler(IChikovMFContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
}
