using AutoMapper;
using ChikovMF.Application.Features.Projects.CreateProject;
using ChikovMF.Application.Features.Projects.GetListProject;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChikovMF.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ProjectListModel>> GetList()
        {
            var query = new GetProjectListQuery();
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

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProjectsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
    }
}
