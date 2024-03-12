using ChikovMF.Application.Features.Files.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ChikovMF.Application.Features.Files.AddOrUpdateFile
{
    public class AddOrUpdateFileCommand : IRequest<FileDto>
    {
        public IFormFile File { get; set; } = null!;
        public string OldNameFile { get; set; } = null!;
    }
}