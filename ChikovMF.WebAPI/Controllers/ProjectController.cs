using ChikovMF.Application.Features.Projects.CreateProject;
using ChikovMF.Application.Features.Projects.DeleteProject;
using ChikovMF.Application.Features.Projects.DetailProject;
using ChikovMF.Application.Features.Projects.EditProject;
using ChikovMF.Application.Features.Projects.GetListProject;
using ChikovMF.Application.Features.Projects.Shared;
using ChikovMF.Application.Features.Projects.UploadProjectSliderImage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost, Authorize]
        public  async Task<ActionResult<Guid>> Create(ProjectDto createProjectModel)
        {
            var command = new CreateProjectCommand
            {
                Project = createProjectModel
            };
            var projectId = await _mediator.Send(command);
            return Ok(projectId);
        }

        [HttpPost("UploadImages/{projectId:guid}"), Authorize]
        public async Task<ActionResult<int>> UploadImages(Guid projectId)
        {
            var fileCollection = Request.Form.Files;
            var command = new UploadProjectImagesCommand
            {
                ProjectId = projectId,
                FileCollection = fileCollection
            };
            var imagesSaved = await _mediator.Send(command);
            return Ok(imagesSaved);
        }

        [HttpDelete("{projectId:guid}"), Authorize]
        public async Task Delete(Guid projectId)
        {
            var command = new DeleteProjectCommand
            {
                ProjectId = projectId
            };
            await _mediator.Send(command);
        }

        [HttpGet("{projectId:guid}")]
        public async Task<ActionResult<DetailProjectModel>> Detail(Guid projectId)
        {
            var query = new DetailProjectQuery
            {
                ProjectId = projectId
            };
            var viewModel = await _mediator.Send(query);

            return Ok(viewModel);
        }

        [HttpGet("Edit/{projectId:guid}"), Authorize]
        public async Task<ActionResult<ProjectDto>> GetEdit(Guid projectId)
        {
            var query = new EditProjectQuery
            {
                ProjectId = projectId
            };
            var viewModel = await _mediator.Send(query);

            return Ok(viewModel);
        }

        [HttpPut("{projectId:guid}"), Authorize]
        public async Task<ActionResult<Guid>> Edit(Guid projectId, ProjectDto editProjectModel)
        {
            var command = new EditProjectCommand
            {
                Project = editProjectModel,
                ProjectId = projectId
            };
            var idModifiedModel = await _mediator.Send(command);
            return Ok(idModifiedModel);
        }

        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
