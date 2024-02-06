using AutoMapper;
using ChikovMF.Application.Features.Projects.CreateProject;
using ChikovMF.Application.Features.Projects.DeleteProject;
using ChikovMF.Application.Features.Projects.GetListProject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChikovMF.WebAPI.Controllers
{
    [Route("api/Projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ListProjectModel>> List()
        {
            var query = new ListProjectQuery();
            var viewModel = await _mediator.Send(query);
            return Ok(viewModel);
        }

        [HttpPost]
        public  async Task<ActionResult<Guid>> Create(CreateProjectModel createProjectModel)
        {
            var command = new CreateProjectCommand
            {
                Project = createProjectModel
            };
            var projectId = await _mediator.Send(command);
            return Ok(projectId);
        }

        [HttpDelete("{projectId:guid}")]
        public async Task Delete(Guid projectId)
        {
            var command = new DeleteProjectCommand
            {
                ProjectId = projectId
            };
            await _mediator.Send(command);
        }

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProjectController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
    }
}
