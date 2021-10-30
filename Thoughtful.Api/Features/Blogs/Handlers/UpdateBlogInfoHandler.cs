using Thoughtful.Api.Features.Blogs.Commands;
using Thoughtful.Dal;

namespace Thoughtful.Api.Features.Blogs.Handlers
{
    public class UpdateBlogInfoHandler : IRequestHandler<UpdateBlogInfo>
    {
        private readonly ThoughtfulDbContext _ctx;
        public UpdateBlogInfoHandler(ThoughtfulDbContext ctx)
        {
            _ctx = ctx;
        }
        
        public async Task<Unit> Handle(UpdateBlogInfo request, CancellationToken cancellationToken)
        {
            var blog = await _ctx.Blogs.FirstOrDefaultAsync(b => b.Id == request.BlogId);

            if (blog != null)
                blog.UpdateBlogInfo(request.Name, request.Description);

            await _ctx.SaveChangesAsync();
            return new Unit();
        }
    }
}
