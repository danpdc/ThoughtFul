using Thoughtful.Api.Features.Blogs.Endpoints;
using Thoughtful.Domain.Model;

namespace Thoughtful.Api.Features.Blogs.AutoMapperProfiles
{
    public class BlogReadsProfiles : Profile
    {
        public BlogReadsProfiles()
        {
            CreateMap<Thoughtful.Domain.Model.Author, BlogReadsEndpoint.Author>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Bio, opt => opt.MapFrom(src => src.Bio));

            CreateMap<Blog, BlogReadsEndpoint.Blog>();

            CreateMap<Thoughtful.Domain.Model.Author, BlogReadsEndpoint.Contributor>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Bio, opt => opt.MapFrom(src => src.Bio))
                .ForMember(dest => dest.ContributorId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
