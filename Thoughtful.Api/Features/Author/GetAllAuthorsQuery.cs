using Thoughtful.Domain.Model;

namespace Thoughtful.Api.Features.AuthorFeature
{
    public class GetAllAuthorsQuery : IRequest<List<AuthorGetDto>>
    {
    }
}
