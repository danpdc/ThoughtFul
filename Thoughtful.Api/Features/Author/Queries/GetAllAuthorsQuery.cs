using Thoughtful.Api.Features.AuthorFeature;
using Thoughtful.Domain.Model;

namespace Thoughtful.Api.Features.Author.Queries
{
    public class GetAllAuthorsQuery : IRequest<List<AuthorGetDto>>
    {
    }
}
