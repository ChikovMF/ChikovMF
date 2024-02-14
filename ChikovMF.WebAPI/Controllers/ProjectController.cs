using AutoMapper;
using ChikovMF.Application.Features.Projects.CreateProject;
using ChikovMF.Application.Features.Projects.DeleteProject;
using ChikovMF.Application.Features.Projects.DetailProject;
using ChikovMF.Application.Features.Projects.EditProject;
using ChikovMF.Application.Features.Projects.GetListProject;
using ChikovMF.Application.Features.Projects.UploadProjectCardImage;
using ChikovMF.Application.Features.Tags.EditTag;
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

        [HttpPost("UploadCardImage/{projectId:guid}")]
        public async Task<ActionResult<string>> UploadCardImage(Guid projectId, [FromForm] IFormFile? image)
        {
            var command = new UploadProjectCardImageCommand
            {
                ProjectId = projectId,
                ImageStream = image?.OpenReadStream()
            };
            var imageSrc = await _mediator.Send(command);
            return Ok(imageSrc);
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

        [HttpGet("Edit/{projectId:guid}")]
        public async Task<ActionResult<EditProjectModel>> GetEdit(Guid projectId)
        {
            var query = new EditProjectQuery
            {
                ProjectId = projectId
            };
            var viewModel = await _mediator.Send(query);

            return Ok(viewModel);
        }

        [HttpPut("{projectId:guid}")]
        public async Task<ActionResult<Guid>> Edit(Guid projectId, EditProjectModel editProjectModel)
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
