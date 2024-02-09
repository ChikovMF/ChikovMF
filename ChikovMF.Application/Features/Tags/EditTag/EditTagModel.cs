using AutoMapper;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Entities;

namespace ChikovMF.Application.Features.Tags.EditTag;

public class EditTagModel : IMapWith<Tag>
{
    public string Name { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Tag, EditTagModel>();
    }
}
