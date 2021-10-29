namespace Thoughtful.Api.Features.Author.Commands
{
    public class DeleteAuthor : IRequest
    {
        public int AuthorId { get; init; }
    }
}
