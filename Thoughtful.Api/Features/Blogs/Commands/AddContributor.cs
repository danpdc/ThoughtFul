namespace Thoughtful.Api.Features.Blogs.Commands
{
    public class AddContributor : IRequest
    {
        public int BlogId { get; init; }
        public int ContributorId { get; init; }
    }
}
