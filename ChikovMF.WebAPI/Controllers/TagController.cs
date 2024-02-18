using AutoMapper;
using ChikovMF.Application.Features.Tags.CreateTag;
using ChikovMF.Application.Features.Tags.DeleteTag;
using ChikovMF.Application.Features.Tags.EditTag;
using ChikovMF.Application.Features.Tags.ListTag;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChikovMF.WebAPI.Controllers
{
    [Route("api/Tags")]
    [ApiController]
    [Authorize]
    public class TagController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<ListTagModel>> List()
        {
            var query = new ListTagQuery();
            var viewModel = await _mediator.Send(query);
            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateTagModel createTagModel)
        {
            var command = new CreateTagCommand
            {
                Tag = createTagModel
            };
            var tagId = await _mediator.Send(command);
            return Ok(tagId);
        }

        [HttpDelete("{tagId:guid}")]
        public async Task Delete(Guid tagId)
        {
            var command = new DeleteTagCommand
            {
                TagId = tagId
            };
            await _mediator.Send(command);
        }

        [HttpGet("Edit/{tagId:guid}")]
        public async Task<ActionResult<EditTagModel>> GetEdit(Guid tagId)
        {
            var query = new EditTagQuery
            {
                TagId = tagId
            };
            var viewModel = await _mediator.Send(query);
            return Ok(viewModel);
        }

        [HttpPut("{tagId:guid}")]
        public async Task<ActionResult<Guid>> Edit(Guid tagId, EditTagModel editTagModel)
        {
            var command = new EditTagCommand
            {
                Tag = editTagModel,
                TagId = tagId
            };
            var idModifiedModel = await _mediator.Send(command);
            return Ok(idModifiedModel);
        }

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TagController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
    }
}
