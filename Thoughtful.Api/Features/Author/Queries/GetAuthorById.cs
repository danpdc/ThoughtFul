using Thoughtful.Api.Features.AuthorFeature;

namespace Thoughtful.Api.Features.Author.Queries
{
    public class GetAuthorById : IRequest<AuthorGetDto>
    {
        public int AuthorId { get; set; }
    }
}
