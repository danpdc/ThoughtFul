using Thoughtful.Api.Features.Blogs.Commands;
using Thoughtful.Dal;

namespace Thoughtful.Api.Features.Blogs.Handlers
{
    public class AddContributorHandler : IRequestHandler<AddContributor>
    {
        private readonly ThoughtfulDbContext _ctx;
        public AddContributorHandler(ThoughtfulDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Unit> Handle(AddContributor request, CancellationToken cancellationToken)
        {
            var blog = await _ctx.Blogs.Include(b => b.Contributors)
                .FirstOrDefaultAsync(b => b.Id == request.BlogId);

            var contributor = await _ctx.Authors.FirstOrDefaultAsync(a => a.Id == request.ContributorId);

            if (blog != null && contributor != null)
                blog.AddContributor(contributor);

            await _ctx.SaveChangesAsync();
            return new Unit();
        }
    }
}
