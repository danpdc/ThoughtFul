using Thoughtful.Api.Features.Blogs.Endpoints;

namespace Thoughtful.Api.Features.Blogs.Commands
{
    public class CreateBlog : IRequest<BlogReadsEndpoint.Blog>
    {
        public BlogsWritesEndpoint.BlogCreate NewBlog { get; set; }
    }
}
