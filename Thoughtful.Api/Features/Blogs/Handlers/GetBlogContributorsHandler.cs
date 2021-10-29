using Thoughtful.Api.Features.Blogs.Endpoints;
using Thoughtful.Api.Features.Blogs.Queries;
using Thoughtful.Dal;

namespace Thoughtful.Api.Features.Blogs.Handlers
{
    public class GetBlogContributorsHandler : IRequestHandler<GetBlogContributors, List<BlogReadsEndpoint.Contributor>>
    {
        private readonly ThoughtfulDbContext _ctx;
        private readonly IMapper _mapper;
        public GetBlogContributorsHandler(ThoughtfulDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        
        public async Task<List<BlogReadsEndpoint.Contributor>> Handle(GetBlogContributors request, CancellationToken cancellationToken)
        {
            var blog = await _ctx.Blogs.Include(b => b.Contributors)
                .FirstOrDefaultAsync(b => b.Id == request.BlogId);

            if (blog != null)
                return _mapper.Map<List<BlogReadsEndpoint.Contributor>>(blog.Contributors);

            return new List<BlogReadsEndpoint.Contributor>();
        }
    }
}
