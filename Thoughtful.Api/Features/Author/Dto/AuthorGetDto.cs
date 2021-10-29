namespace Thoughtful.Api.Features.AuthorFeature
{
    public record AuthorGetDto
    {
        public int Id { get; init; } 
        public string Name { get; init; } 
        public string Bio { get; init; }
        public DateTime DateOfBirth { get; init; }
    } 
}
