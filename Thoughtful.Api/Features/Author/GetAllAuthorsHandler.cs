using Thoughtful.Dal;
using Thoughtful.Domain.Model;

namespace Thoughtful.Api.Features.AuthorFeature
{
    public class GetAllAuthorsHandler : IRequestHandler<GetAllAuthorsQuery, List<Author>>
    {
        private readonly ThoughtfulDbContext _ctx;
        public GetAllAuthorsHandler(ThoughtfulDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<List<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            return await _ctx.Authors.ToListAsync();
        }
    }
}
