namespace Thoughtful.Api.Features.Author.Commands
{
    public class UpdateAuthor : IRequest
    {
        public int AuthorId { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Bio { get; init; }
        public DateTime DateOfBirth { get; init; }
    }
}
