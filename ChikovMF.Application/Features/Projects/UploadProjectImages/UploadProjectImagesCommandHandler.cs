using ChikovMF.Application.Common.Exceptions;
using ChikovMF.Application.Common.Interfaces;
using ChikovMF.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace ChikovMF.Application.Features.Projects.UploadProjectSliderImage;

public class UploadProjectImagesCommandHandler : IRequestHandler<UploadProjectImagesCommand, int>
{
    public async Task<int> Handle(UploadProjectImagesCommand request, CancellationToken cancellationToken)
    {
        var project = await _context.Projects
            .Include(p => p.Images)
            .FirstOrDefaultAsync(p => p.ProjectId == request.ProjectId, cancellationToken);

        if (project == null)
        {
            throw new NotFoundEntityException(nameof(Project), request.ProjectId);
        }

        string pathLocation = Path.Combine(Directory.GetCurrentDirectory(), $"Images");

        if (project.Images != null && project.Images.Count > 0)
        {
            foreach (var image in project.Images)
            {
                string saveLocation = Path.Combine(pathLocation, image.FileName);

                if (File.Exists(saveLocation))
                {
                    File.Delete(saveLocation);
                }
            }
        }

        project.Images = new List<ProjectImage>(request.FileCollection.Count);

        foreach (var file in request.FileCollection)
        {
            string saveLocation, fileName;

            do
            {
                fileName = $"{Guid.NewGuid()}.jpg";
                saveLocation = Path.Combine(pathLocation, fileName);
            }
            while (File.Exists(saveLocation));

            ImageType imageType;
            string alt = string.Empty;
            ResizeOptions resizeOptions;

            switch (file.Name)
            {
                case "card":
                    imageType = ImageType.Card;
                    alt = $"Изображение карточки проекта: {project.Name}";
                    resizeOptions = new ResizeOptions
                    {
                        Mode = ResizeMode.Crop,
                        Size = new Size(640, 426)
                    };
                    break;

                case "slider":
                    imageType = ImageType.Slide;
                    alt = $"Изображение для слайдера проекта: {project.Name}";
                    resizeOptions = new ResizeOptions
                    {
                        Mode = ResizeMode.Crop,
                        Size = new Size(1920, 1080)
                    };
                    break;

                default:
                    throw new ArgumentException($"Could not determine image type ({file.Name})");
            }

            using (var processedImage = Image.Load(file.OpenReadStream()))
            {
                processedImage.Mutate(x => x.Resize(resizeOptions));
                await processedImage.SaveAsJpegAsync(saveLocation);
            }

            project.Images.Add(new ProjectImage
            {
                FileName = fileName,
                ImageType = imageType,
                Src = $"/Images/{fileName}",
                Alt = alt
            });
        }

        await _context.SaveChangesAsync(cancellationToken);

        return request.FileCollection.Count;
    }

    private readonly IChikovMFContext _context;

    public UploadProjectImagesCommandHandler(IChikovMFContext context)
    {
        _context = context;
    }
}
