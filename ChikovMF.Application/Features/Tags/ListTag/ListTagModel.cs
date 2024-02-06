using AutoMapper;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Entities;

namespace ChikovMF.Application.Features.Tags.ListTag;

public class ListTagModel
{
    public ICollection<TagItemListModel>? Tags { get; set; }
}

public class TagItemListModel : IMapWith<Tag>
{
    public Guid TagId { get; set; }
    public string Name { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Tag, TagItemListModel>();
    }
}
