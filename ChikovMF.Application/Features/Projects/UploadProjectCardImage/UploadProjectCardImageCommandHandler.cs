using ChikovMF.Application.Common.Exceptions;
using ChikovMF.Application.Interfaces;
using ChikovMF.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ChikovMF.Application.Features.Projects.UploadProjectCardImage;

public class UploadProjectCardImageCommandHandler : IRequestHandler<UploadProjectCardImageCommand, string>
{
    public async Task<string> Handle(UploadProjectCardImageCommand request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects
            .Include(p => p.Images)
            .FirstOrDefaultAsync(p => p.ProjectId == request.ProjectId, cancellationToken);

        if (project == null)
        {
            throw new NotFoundEntityException(nameof(Project), request.ProjectId);
        }

        string filename, saveLocation;
        string pathLocation = Path.Combine(Directory.GetCurrentDirectory(), $"Images");

        var image = project.Images?.FirstOrDefault(i => i.ImageType == ImageType.Card);

        if (image == null)
        {
            if (request.ImageStream == null)
            {
                return string.Empty;
            }

            do
            {
                filename = $"{Guid.NewGuid()}.jpg";
                saveLocation = Path.Combine(pathLocation, filename);
            }
            while (File.Exists(saveLocation));

            project.Images?.Add(new ProjectImage
            {
                ImageType = ImageType.Card,
                Src = $"/Images/{filename}",
                Alt = $"Изображение для карточки проекта: {project.Name}"
            });
        }
        else
        {
            filename = image.Src.Split('/').Last();
            saveLocation = Path.Combine(pathLocation, filename);

            if (File.Exists(saveLocation))
            {
                File.Delete(saveLocation);
            }

            if (request.ImageStream == null)
            {
                project.Images?.Remove(image);
                await _context.SaveChangesAsync(cancellationToken);
                return string.Empty;
            }
        }

        ResizeOptions resizeOptions = new ResizeOptions
        {
            Mode = ResizeMode.Crop,
            Size = new Size(640, 426)
        };

        using (var processedImage = Image.Load(request.ImageStream))
        {
            processedImage.Mutate(x => x.Resize(resizeOptions));
            await processedImage.SaveAsJpegAsync(saveLocation);
        }

        await _context.SaveChangesAsync(cancellationToken);

        return $"/Images/{filename}";
    }

    private readonly IChikovMFContext _context;

    public UploadProjectCardImageCommandHandler(IChikovMFContext context)
    {
        _context = context;
    }
}
