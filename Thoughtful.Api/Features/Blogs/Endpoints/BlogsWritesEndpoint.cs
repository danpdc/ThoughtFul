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
                .Produces<BlogCreate>(201)
                .Produces(500);

            endpoints.MapPost("api/blogs/{blogId}/contributors", async (int blogId, ContributorAdd contributor)
                => await AddBlogContributor(blogId, contributor))
                .WithName("AddContributor")
                .WithDisplayName("Blogs")
                .Produces(204)
                .Produces(500);

            endpoints.MapDelete("api/blogs/{blogdId}/contributors/{contributorId}",  async (int blogId, int contributorId) 
                => await RemoveContributor(blogId, contributorId))
                .WithName("RemoveContributor")
                .WithDisplayName("Blogs")
                .Produces(204)
                .Produces(500);

            endpoints.MapPut("api/blogs/{blogId}/owner", async (int blogId, OwnerUpdate newOwner) 
                => await UpdateOwner(blogId, newOwner))
                .WithName("UpdateBlogOwner")
                .WithDisplayName("Blogs")
                .Produces(204)
                .Produces(500);

            endpoints.MapPut("api/blogs/{blogId}", async (int blogId, BlogInfo info) 
                => await UpdateInfo(blogId, info))
                .WithName("UpdateBlogInfo")
                .WithDisplayName("Blogs")
                .Produces(204)
                .Produces(500);

            return endpoints;
        }

        private async Task<IResult> CreateBlog(BlogCreate blog)
        {
            var command = new CreateBlog { NewBlog = blog};
            var result = await _mediator.Send(command);
            return Results.CreatedAtRoute("GetBlogById", new { Id = result.Id }, result);
        }

        private async Task<IResult> AddBlogContributor(int blogId, ContributorAdd contributor)
        {
            var command = new AddContributor { BlogId = blogId, ContributorId = contributor.ContributorId};
            await _mediator.Send(command);
            return Results.NoContent();
        }

        private async Task<IResult> RemoveContributor(int blogId, int contributorId)
        {
            var command = new RemoveBlogContributor { BlogId = blogId, ContributorId = contributorId };
            await _mediator.Send(command);
            return Results.NoContent();
        }

        private async Task<IResult> UpdateOwner(int blogId, OwnerUpdate newOwner)
        {
            var command = new UpdateBlogOwner { BlogId = blogId, OnwerId = newOwner.OwnerId};
            await _mediator.Send(command);
            return Results.NoContent();
        }

        private async Task<IResult> UpdateInfo(int blogId, BlogInfo info)
        {
            var command = new UpdateBlogInfo { BlogId = blogId, Name = info.Name, Description = info.Description };
            await _mediator.Send(command);
            return Results.NoContent();
        }

        public record BlogCreate(string Name, string Description, int AuhtorId);
        public record ContributorAdd(int ContributorId);
        public record OwnerUpdate(int OwnerId);
        public record BlogInfo(string Name, string Description);
    }  
}
