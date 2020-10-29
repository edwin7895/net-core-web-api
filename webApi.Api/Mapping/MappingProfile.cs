using AutoMapper;
using webApi.Api.Resources;
using webApi.Core.Models;

namespace webApi.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // From domain to resource
            CreateMap<Music,MusicResource>();
            CreateMap<Artist, ArtistResource>();
            // From resource to domain
            CreateMap<MusicResource,Music>();
            CreateMap<ArtistResource,Artist>();

            CreateMap<SaveMusicResource, Music>();
            CreateMap<SaveArtistResource, Artist>();
        }
    }
}