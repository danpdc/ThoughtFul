using Thoughtful.Api.Features.Blogs.Commands;
using Thoughtful.Dal;

namespace Thoughtful.Api.Features.Blogs.Handlers
{
    public class RemoveBlogContributorHandler : IRequestHandler<RemoveBlogContributor>
    {
        private readonly ThoughtfulDbContext _ctx;
        public RemoveBlogContributorHandler(ThoughtfulDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Unit> Handle(RemoveBlogContributor request, CancellationToken cancellationToken)
        {
            var blog = await _ctx.Blogs.Include(b => b.Contributors)
                .FirstOrDefaultAsync(b => b.Id == request.BlogId);

            var author = await _ctx.Authors.FirstOrDefaultAsync(a => a.Id == request.ContributorId);

            if (blog != null && author != null)
                blog.RemoveContributor(author);

            await _ctx.SaveChangesAsync();
            return new Unit();
        }
    }
}
