using Thoughtful.Api.Features.Author.Queries;
using Thoughtful.Api.Features.AuthorFeature;
using Thoughtful.Dal;

namespace Thoughtful.Api.Features.Author.Handlers
{
    public class GetAuthorByIdHandler : IRequestHandler<GetAuthorById, AuthorGetDto>
    {
        private readonly ThoughtfulDbContext _ctx;
        private readonly IMapper _mapper; 
        public GetAuthorByIdHandler(ThoughtfulDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<AuthorGetDto> Handle(GetAuthorById request, CancellationToken cancellationToken)
        {
            var author = await _ctx.Authors.FirstOrDefaultAsync(a => a.Id == request.AuthorId);
            return _mapper.Map<AuthorGetDto>(author);
        }
    }
}
