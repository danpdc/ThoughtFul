using Thoughtful.Dal;
using Thoughtful.Domain.Model;

namespace Thoughtful.Api.Features.AuthorFeature
{
    public class GetAllAuthorsHandler : IRequestHandler<GetAllAuthorsQuery, List<AuthorGetDto>>
    {
        private readonly ThoughtfulDbContext _ctx;
        private readonly IMapper _mapper;
        public GetAllAuthorsHandler(ThoughtfulDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<List<AuthorGetDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _ctx.Authors.ToListAsync();
            return _mapper.Map<List<AuthorGetDto>>(authors);
        }
    }
}
