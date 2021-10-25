using Thoughtful.Api.Features.Blogs.Endpoints;

namespace Thoughtful.Api.Features.Blogs.Queries
{
    public class GetAllBlogs : IRequest<List<BlogReadsEndpoint.Blog>>
    {
    }
}
