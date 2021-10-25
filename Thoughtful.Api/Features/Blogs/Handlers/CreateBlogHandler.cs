using Thoughtful.Api.Features.Blogs.Commands;
using Thoughtful.Api.Features.Blogs.Endpoints;
using Thoughtful.Dal;
using Thoughtful.Domain.Model;

namespace Thoughtful.Api.Features.Blogs.Handlers
{
    public class CreateBlogHandler : IRequestHandler<CreateBlog, BlogReadsEndpoint.Blog>
    {
        private readonly ThoughtfulDbContext _ctx;
        private readonly IMapper _mapper;

        public CreateBlogHandler(ThoughtfulDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<BlogReadsEndpoint.Blog> Handle(CreateBlog request, CancellationToken cancellationToken)
        {
            var blog = Blog.CreateBlog(request.NewBlog.Name, request.NewBlog.Description, 
                request.NewBlog.AuhtorId);

            _ctx.Blogs.Add(blog);
            await _ctx.SaveChangesAsync();
            var author = await _ctx.Authors.FirstOrDefaultAsync(a => a.Id == blog.AuthorId);
            blog.SetOwner(author);

            return _mapper.Map<BlogReadsEndpoint.Blog>(blog);
        }
    }
}
