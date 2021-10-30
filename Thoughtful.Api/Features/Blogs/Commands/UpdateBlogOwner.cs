namespace Thoughtful.Api.Features.Blogs.Commands
{
    public class UpdateBlogOwner : IRequest
    {
        public int BlogId { get; init; }
        public int OnwerId { get; init; }   
    }
}
