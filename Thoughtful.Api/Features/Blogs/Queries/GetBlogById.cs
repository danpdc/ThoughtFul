using Thoughtful.Api.Features.Blogs.Endpoints;

namespace Thoughtful.Api.Features.Blogs.Queries
{
    public class GetBlogById : IRequest<BlogReadsEndpoint.Blog>
    {
        public int BlogId { get; set; }
    }
}
