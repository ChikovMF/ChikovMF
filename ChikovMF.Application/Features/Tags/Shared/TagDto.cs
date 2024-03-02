using AutoMapper;
using ChikovMF.Application.Common.Mappings;
using ChikovMF.Entities;

namespace ChikovMF.Application.Features.Tags.Shared
{
    public class TagDto : IMapWith<Tag>
    {
        public string Name { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TagDto, Tag>();
            profile.CreateMap<Tag, TagDto>();
        }
    }
}