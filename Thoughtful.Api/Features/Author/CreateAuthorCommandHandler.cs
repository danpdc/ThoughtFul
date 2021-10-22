using Thoughtful.Dal;
using Thoughtful.Domain.Model;

namespace Thoughtful.Api.Features.AuthorFeature
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Author>
    {
        private readonly ThoughtfulDbContext _ctx;
        private readonly IMapper _mapper;
        public CreateAuthorCommandHandler(ThoughtfulDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<Author> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var toAdd = _mapper.Map<Author>(request.Author);
            _ctx.Authors.Add(toAdd);
            await _ctx.SaveChangesAsync();
            return toAdd;
        }
    }
}
