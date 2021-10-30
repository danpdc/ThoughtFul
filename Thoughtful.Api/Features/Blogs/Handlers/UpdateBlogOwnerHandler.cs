using Thoughtful.Api.Features.Blogs.Commands;
using Thoughtful.Dal;

namespace Thoughtful.Api.Features.Blogs.Handlers
{
    public class UpdateBlogOwnerHandler : IRequestHandler<UpdateBlogOwner>
    {
        private readonly ThoughtfulDbContext _ctx;
        public UpdateBlogOwnerHandler(ThoughtfulDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Unit> Handle(UpdateBlogOwner request, CancellationToken cancellationToken)
        {
            var blog = await _ctx.Blogs.Include(b => b.Owner)
                .FirstOrDefaultAsync(b => b.Id == request.BlogId);

            var owner = await _ctx.Authors.FirstOrDefaultAsync(a => a.Id == request.OnwerId);

            if (blog != null && owner != null)
                blog.SetOwner(owner);

            await _ctx.SaveChangesAsync();
            return new Unit();
        }
    }
}
