using MediatR;

namespace ChikovMF.Application.Features.Files.DeleteFile
{
    public class DeleteFileCommand : IRequest<bool>
    {
        public string PathLocation { get; set; } = default!;
        public string FileName { get; set; } = default!;
    }
}