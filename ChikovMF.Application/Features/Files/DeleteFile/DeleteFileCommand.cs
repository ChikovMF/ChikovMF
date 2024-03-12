using MediatR;

namespace ChikovMF.Application.Features.Files.DeleteFile
{
    public class DeleteFileCommand : IRequest
    {
        public string FileName { get; set; } = null!;
    }
}