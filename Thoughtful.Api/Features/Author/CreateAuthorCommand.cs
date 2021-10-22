using Thoughtful.Domain.Model;

namespace Thoughtful.Api.Features.AuthorFeature
{
    public class CreateAuthorCommand : IRequest<Author>
    {
        public AuthorDto? Author { get; set; }
    }
}
