using Codewrinkles.MinimalApi.SmartModules;
using Thoughtful.Api.Features.Blogs.Commands;

namespace Thoughtful.Api.Features.Blogs.Endpoints
{
    public class BlogsWritesEndpoint : IEndpointDefinition
    {
        private readonly ILogger<BlogsWritesEndpoint> _logger;
        public BlogsWritesEndpoint(ILogger<BlogsWritesEndpoint> logger)
        {
            _logger = logger;
        }

        public IEndpointRouteBuilder RegisterRoutes(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/api/blogs", async (BlogCreate dto, IMediator mediator) 
                => await CreateBlog(dto, mediator))
                .WithName("Createblog")
                .WithDisplayName("Blogs")
                .Produces<BlogCreate>(201)
                .Produces(500);

            endpoints.MapPost("api/blogs/{blogId}/contributors", async (int blogId, ContributorAdd contributor, 
                IMediator mediator)
                => await AddBlogContributor(blogId, contributor, mediator))
                .WithName("AddContributor")
                .WithDisplayName("Blogs")
                .Produces(204)
                .Produces(500);

            endpoints.MapDelete("api/blogs/{blogdId}/contributors/{contributorId}",  async (int blogId, int contributorId, 
                IMediator mediator) 
                => await RemoveContributor(blogId, contributorId, mediator))
                .WithName("RemoveContributor")
                .WithDisplayName("Blogs")
                .Produces(204)
                .Produces(500);

            endpoints.MapPut("api/blogs/{blogId}/owner", async (int blogId, OwnerUpdate newOwner, 
                IMediator mediator) 
                => await UpdateOwner(blogId, newOwner, mediator))
                .WithName("UpdateBlogOwner")
                .WithDisplayName("Blogs")
                .Produces(204)
                .Produces(500);

            endpoints.MapPut("api/blogs/{blogId}", async (int blogId, BlogInfo info, IMediator mediator) 
                => await UpdateInfo(blogId, info, mediator))
                .WithName("UpdateBlogInfo")
                .WithDisplayName("Blogs")
                .Produces(204)
                .Produces(500);

            return endpoints;
        }

        private async Task<IResult> CreateBlog(BlogCreate blog, IMediator mediator)
        {
            var command = new CreateBlog { NewBlog = blog};
            var result = await mediator.Send(command);
            return Results.CreatedAtRoute("GetBlogById", new { Id = result.Id }, result);
        }

        private async Task<IResult> AddBlogContributor(int blogId, ContributorAdd contributor, IMediator mediator)
        {
            var command = new AddContributor { BlogId = blogId, ContributorId = contributor.ContributorId};
            await mediator.Send(command);
            return Results.NoContent();
        }

        private async Task<IResult> RemoveContributor(int blogId, int contributorId, IMediator mediator)
        {
            var command = new RemoveBlogContributor { BlogId = blogId, ContributorId = contributorId };
            await mediator.Send(command);
            return Results.NoContent();
        }

        private async Task<IResult> UpdateOwner(int blogId, OwnerUpdate newOwner, IMediator mediator)
        {
            var command = new UpdateBlogOwner { BlogId = blogId, OnwerId = newOwner.OwnerId};
            await mediator.Send(command);
            return Results.NoContent();
        }

        private async Task<IResult> UpdateInfo(int blogId, BlogInfo info, IMediator mediator)
        {
            var command = new UpdateBlogInfo { BlogId = blogId, Name = info.Name, Description = info.Description };
            await mediator.Send(command);
            return Results.NoContent();
        }

        public record BlogCreate(string Name, string Description, int AuhtorId);
        public record ContributorAdd(int ContributorId);
        public record OwnerUpdate(int OwnerId);
        public record BlogInfo(string Name, string Description);
    }  
}
