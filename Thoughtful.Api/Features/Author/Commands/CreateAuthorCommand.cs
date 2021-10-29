using Thoughtful.Domain.Model;

namespace Thoughtful.Api.Features.AuthorFeature
{
    public class CreateAuthorCommand : IRequest<AuthorGetDto>
    {
        public AuthorDto? Author { get; set; }
    }
}
