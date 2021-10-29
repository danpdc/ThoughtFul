using Thoughtful.Dal;
using Thoughtful.Domain.Model;

namespace Thoughtful.Api.Features.AuthorFeature
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, AuthorGetDto>
    {
        private readonly ThoughtfulDbContext _ctx;
        private readonly IMapper _mapper;
        public CreateAuthorCommandHandler(ThoughtfulDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<AuthorGetDto> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var toAdd = _mapper.Map<Thoughtful.Domain.Model.Author>(request.Author);
            _ctx.Authors.Add(toAdd);
            await _ctx.SaveChangesAsync();
            return _mapper.Map<AuthorGetDto>(toAdd);
        }
    }
}
