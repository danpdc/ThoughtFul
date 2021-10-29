using Thoughtful.Api.Features.Author.Commands;
using Thoughtful.Dal;

namespace Thoughtful.Api.Features.Author.Handlers
{
    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthor>
    {
        private readonly ThoughtfulDbContext _ctx;
        public UpdateAuthorHandler(ThoughtfulDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Unit> Handle(UpdateAuthor request, CancellationToken cancellationToken)
        {
            var author = await _ctx.Authors.FirstOrDefaultAsync(a => a.Id == request.AuthorId);
            if (!(author is null))
                author.UpdateAuthor(request.FirstName, request.LastName, request.Bio, request.DateOfBirth);

            await _ctx.SaveChangesAsync();
            return new Unit();
        }
    }
}
