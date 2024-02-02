using ChikovMF.Application.Features.Projects.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChikovMF.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var query = new GetProjectListQuery();
            var viewModel = await _mediator.Send(query);
            return Ok(viewModel);
        }

        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
