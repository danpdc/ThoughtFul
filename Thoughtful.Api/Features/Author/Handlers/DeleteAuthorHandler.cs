using Thoughtful.Api.Features.Author.Commands;
using Thoughtful.Dal;

namespace Thoughtful.Api.Features.Author.Handlers
{
    public class DeleteAuthorHandler : IRequestHandler<DeleteAuthor>
    {
        private readonly ThoughtfulDbContext _ctx;
        public DeleteAuthorHandler(ThoughtfulDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Unit> Handle(DeleteAuthor request, CancellationToken cancellationToken)
        {
            var author = await _ctx.Authors.FirstOrDefaultAsync(a => a.Id == request.AuthorId);

            if (author != null)
                _ctx.Authors.Remove(author);

            await _ctx.SaveChangesAsync();
            return new Unit();
        }
    }
}
