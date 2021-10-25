using Thoughtful.Api.Features.Blogs.Endpoints;
using Thoughtful.Api.Features.Blogs.Queries;
using Thoughtful.Dal;

namespace Thoughtful.Api.Features.Blogs.Handlers
{
    public class GetAllBlogsHandler : IRequestHandler<GetAllBlogs, List<BlogReadsEndpoint.Blog>>
    {
        private readonly ThoughtfulDbContext _ctx;
        private readonly IMapper _mapper;
        public GetAllBlogsHandler(ThoughtfulDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<List<BlogReadsEndpoint.Blog>> Handle(GetAllBlogs request, CancellationToken cancellationToken)
        {
            var blogs = await _ctx.Blogs.Include(b => b.Owner).ToListAsync();

            return _mapper.Map<List<BlogReadsEndpoint.Blog>>(blogs);
        }
    }
}
