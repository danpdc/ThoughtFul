using Thoughtful.Dal;

namespace Thoughtful.Api.Features.Blogs.Endpoints
{
    public class BlogCommonEndpoint : IEndpoint
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public BlogCommonEndpoint(IMediator mediator, IMapper mapper)
        {
            _mapper = mapper;
            _mediator = mediator;
        }
        public IEndpointRouteBuilder RegisterRoutes(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/blogs", async (ThoughtfulDbContext ctx) =>
            {
                return await ctx.Blogs.ToListAsync();
            })
                .WithDisplayName("Blogs")
                .WithName("Blogs");
            return endpoints;
        }
    }
}
