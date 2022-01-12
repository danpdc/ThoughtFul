using Codewrinkles.MinimalApi.SmartModules;
using Codewrinkles.MinimalApi.SmartModules.Extensions.SmartEndpointsExtensions;
using Thoughtful.Api.Features.Blogs.Queries;
using Thoughtful.Dal;

namespace Thoughtful.Api.Features.Blogs.Endpoints
{
    public class BlogReadsEndpoint : IEndpointDefinition
    {
        private readonly ILogger<BlogReadsEndpoint> _logger;
        public BlogReadsEndpoint(ILogger<BlogReadsEndpoint> logger)
        {
            _logger = logger;
        }

        public IEndpointRouteBuilder RegisterRoutes(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapSmartGet("/api/blogs", async (IMediator mediator) => await GetAllBlogs(mediator))
                .WithDisplayName("Blogs")
                .WithName("GetBlogs")
                .Produces<List<Blog>>();
            _logger.LogInformation("Added endpoint: /api/blogs");

            endpoints.MapSmartGet("/api/blogs/{id}", async (IMediator mediator, int id) 
                => await GetBlogById(id, mediator))
                .WithName("GetBlogById")
                .WithDisplayName("Blogs")
                .Produces<Blog>()
                .Produces(404)
                .Produces(500);

            endpoints.MapSmartGet("api/blogs/{blogId}/contributors", async (IMediator mediator, int blogId)
                => await GetBlogContribtuors(blogId, mediator))
                .WithName("GetBlogContributors")
                .WithDisplayName("Blogs")
                .Produces<List<Contributor>>()
                .Produces(500);
            return endpoints;
        }

        private async Task<IResult> GetAllBlogs(IMediator mediator)
        {
            var result = await mediator.Send(new GetAllBlogs());
            return Results.Ok(result);
        }

        private async Task<IResult> GetBlogById(int id, IMediator mediator)
        {
            var result = await mediator.Send(new GetBlogById { BlogId = id});
            if (result is null)
                return Results.NotFound();

            return Results.Ok(result);
        }

        private async Task<IResult> GetBlogContribtuors(int blogId, IMediator mediator)
        {
            var query = new Thoughtful.Api.Features.Blogs.Queries.GetBlogContributors
            {
                BlogId = blogId
            };

            var result = await mediator.Send(query);
            return Results.Ok(result);
        }

        public record Blog
        {
            public int Id { get; init; }
            public string Name { get; init; }
            public string Description { get; init; }    
            public DateTime DateCreated { get; init; }
            public Author Owner { get; init; }
        }

        public record Author
        {
            public string Name { get; init; }
            public string Bio { get; init; }
        }
        public record Contributor
        {
            public int ContributorId { get; init; }
            public string Name { get; init; }
            public string Bio { get; init; }
        }
    }
}
