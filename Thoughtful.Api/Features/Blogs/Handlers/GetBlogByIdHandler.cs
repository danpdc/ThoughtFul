using Thoughtful.Api.Features.Blogs.Endpoints;
using Thoughtful.Api.Features.Blogs.Queries;
using Thoughtful.Dal;

namespace Thoughtful.Api.Features.Blogs.Handlers
{
    public class GetBlogByIdHandler : IRequestHandler<GetBlogById, BlogReadsEndpoint.Blog>
    {
        private readonly ThoughtfulDbContext _ctx;
        private readonly IMapper _mapper;

        public GetBlogByIdHandler(ThoughtfulDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<BlogReadsEndpoint.Blog> Handle(GetBlogById request, CancellationToken cancellationToken)
        {
            var blog = await _ctx.Blogs.FirstOrDefaultAsync(b => b.Id == request.BlogId);
            return _mapper.Map<BlogReadsEndpoint.Blog>(blog);
        }
    }
}
