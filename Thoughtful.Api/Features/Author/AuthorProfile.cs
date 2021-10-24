using Thoughtful.Api.Features.AuthorFeature;
using Thoughtful.Domain.Model;

namespace Thoughtful.Api.Features.AuthorFeature
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorDto, Author>().ReverseMap();
            CreateMap<Author, AuthorGetDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName));
        }
    }
}
