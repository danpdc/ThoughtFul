namespace Thoughtful.Api.Features.Blogs.Commands
{
    public class UpdateBlogInfo : IRequest
    {
        public int BlogId { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
    }
}
