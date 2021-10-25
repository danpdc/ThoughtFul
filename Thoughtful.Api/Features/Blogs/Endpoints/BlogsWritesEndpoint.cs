using Thoughtful.Api.Features.Blogs.Commands;

namespace Thoughtful.Api.Features.Blogs.Endpoints
{
    public class BlogsWritesEndpoint : IEndpoint
    {
        private readonly IMediator _mediator;

        public BlogsWritesEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IEndpointRouteBuilder RegisterRoutes(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/api/blogs", async (BlogCreate dto) => await CreateBlog(dto))
                .WithName("Createblog")
                .WithDisplayName("Blogs")
                .Produces<BlogCreate>()
                .Produces(500);
            return endpoints;
        }

        private async Task<IResult> CreateBlog(BlogCreate blog)
        {
            var command = new CreateBlog { NewBlog = blog};
            var result = await _mediator.Send(command);
            return Results.Ok(result);
        }

        public record BlogCreate(string Name, string Description, int AuhtorId);
    }  
}
