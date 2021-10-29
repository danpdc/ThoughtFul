namespace Thoughtful.Api.Features.Blogs.Commands
{
    public class RemoveBlogContributor : IRequest
    {
        public int BlogId { get; init; }
        public int ContributorId { get; init; }
    }
}
