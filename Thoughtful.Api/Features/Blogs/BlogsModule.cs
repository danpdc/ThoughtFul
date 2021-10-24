using Thoughtful.Api.Features.Blogs.Endpoints;

namespace Thoughtful.Api.Features.Blogs
{
    public class BlogsModule : IModule
    {
        private IMediator _mediator;
        private IMapper _mapper;
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            new BlogCommonEndpoint(_mediator, _mapper).RegisterRoutes(endpoints);
            new BlogContributorsEndpoint(_mediator, _mapper);
            return endpoints;
        }

        public WebApplicationBuilder RegisterModule(WebApplicationBuilder builder)
        {
            var provider = builder.Services.BuildServiceProvider();
            _mediator = provider.GetRequiredService<IMediator>();
            _mapper = provider.GetRequiredService<IMapper>();
            return builder;
        }
    }
}
