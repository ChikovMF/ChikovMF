using ChikovMF.Application.Features.Files.AddFile;
using ChikovMF.Application.Features.Files.DeleteFile;
using ChikovMF.Application.Features.Files.ListFiles;
using ChikovMF.Application.Features.Files.Shared;
using ChikovMF.Application.Features.Files.UpdateFile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChikovMF.WebAPI.Controllers
{
    [ApiController]
    [Route("api/Files")]
    [Authorize]
    public class FileController : ControllerBase
    {
        private const string PATH_LOCATION = "Files";

        [HttpGet]
        public async Task<ActionResult<ICollection<FileDto>>> List()
        {
            var query = new ListFileQuery 
            {
                PathLocation = PATH_LOCATION
            };
            var viewModel = await _mediator.Send(query);
            return Ok(viewModel);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(string fileName)
        {
            var command = new DeleteFileCommand
            {
                FileName = fileName
                
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Add(IFormFile file)
        {
            var command = new AddFileCommand
            {
                FileStream = file.OpenReadStream(),
                FileName = file.FileName,
                PathLocation = PATH_LOCATION,
            };
            var fileDto = await _mediator.Send(command);
            return Ok(fileDto);
        }

        [HttpPut]
        public async Task<ActionResult> Update(IFormFile file, string fileName)
        {
            var command = new UpdateFileCommand
            {
                FileStream = file.OpenReadStream(),
                FileName = fileName,
                PathLocation = PATH_LOCATION
            };
            var fileDto = await _mediator.Send(command);
            return Ok(fileDto);
        }

        private readonly IMediator _mediator;
        public FileController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
