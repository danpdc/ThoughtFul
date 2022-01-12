using Codewrinkles.MinimalApi.SmartModules;
using Codewrinkles.MinimalApi.SmartModules.Extensions.SmartEndpointsExtensions;
using Thoughtful.Api.Features.Author.Commands;
using Thoughtful.Api.Features.Author.Queries;

namespace Thoughtful.Api.Features.AuthorFeature
{
    public class AuthorModule : SmartModule
    {
        private readonly ILogger<AuthorModule> _logger;
        public AuthorModule(ILogger<AuthorModule> logger)
        {
            _logger = logger;
        }
        public override IEndpointRouteBuilder MapEndpointDefinitions(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapSmartGet("/api/authors", async (IMediator mediator) 
                => await GetAllAuthors(mediator))
                .WithName("GetAllAuthors")
                .WithDisplayName("Authors")
                .WithTags("Authors")
                .Produces<List<AuthorGetDto>>()
                .Produces(500);

            endpoints.MapSmartPost("GET /api/authors", async (AuthorDto authorDto, IMediator mediator) 
                => await CreateAuthor(authorDto, mediator))
                .WithName("CreateAuthor")
                .WithDisplayName("Authors")
                .WithTags("Authors")
                .Produces<AuthorGetDto>(201)
                .Produces(500);

            endpoints.MapSmartGet("api/authors/{id}", async (int id, IMediator mediator) 
                => await GetAuthorById(id, mediator))
                .WithName("GetAuthorById")
                .WithDisplayName("Authors")
                .Produces<AuthorGetDto>()
                .Produces(404)
                .Produces(500);

            endpoints.MapSmartPut("api/authors/{id}", async (int id, AuthorDto authorToUpdate, IMediator mediator) 
                => await UpdateAuthor(id, authorToUpdate, mediator))
                .WithName("UpdateAuthor")
                .WithDisplayName("Authors")
                .Produces(204)
                .Produces(500);

            endpoints.MapSmartDelete("api/authors/{id}", async (int id, IMediator mediator) 
                => await DeleteAuthor(id, mediator))
                .WithName("DeleteAuthor")
                .WithDisplayName("Authors")
                .Produces(204)
                .Produces(500);

            return endpoints;
        }

        /// <summary>
        /// Gets all authors
        /// </summary>
        /// <returns></returns>
        private async Task<IResult> GetAllAuthors(IMediator mediator)
        {
            var authors = await mediator.Send(new GetAllAuthorsQuery());
            return Results.Ok(authors);
        }

        /// <summary>
        /// Creates an author
        /// </summary>
        /// <param name="authorDto"></param>
        /// <returns></returns>
        private async Task<IResult> CreateAuthor(AuthorDto authorDto, IMediator mediator)
        {
            var command = new CreateAuthorCommand { Author = authorDto };
            var result = await mediator.Send(command);
            return Results.CreatedAtRoute("GetAuthorById", new { Id = result.Id}, result);
        }

        private async Task<IResult> GetAuthorById(int id, IMediator mediator)
        {
            var result = await mediator.Send(new GetAuthorById { AuthorId = id});
            if (result is null)
                return Results.NotFound();

            return Results.Ok(result);
        }

        private async Task<IResult> UpdateAuthor(int id, AuthorDto authorToUpdate, IMediator mediator)
        {
            var command = new UpdateAuthor
            {
                AuthorId = id,
                FirstName = authorToUpdate.FirstName,
                LastName = authorToUpdate.LastName,
                Bio = authorToUpdate.Bio,
                DateOfBirth = authorToUpdate.DateOfBirth
            };
            await mediator.Send(command);

            return Results.NoContent();
        }

        private async Task<IResult> DeleteAuthor(int id, IMediator mediator)
        {
            await mediator.Send(new DeleteAuthor { AuthorId = id});
            return Results.NoContent();
        }
    }
}
