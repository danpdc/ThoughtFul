using Microsoft.AspNetCore.Authorization;
using Thoughtful.Api.Features.Author.Commands;
using Thoughtful.Api.Features.Author.Queries;
using Thoughtful.Dal;
using Thoughtful.Domain.Model;

namespace Thoughtful.Api.Features.AuthorFeature
{
    public class AuthorModule : IModule
    {
        private IMediator _mediator;
        private IMapper _mapper;
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/authors", async () => await GetAllAuthors())
                .WithName("GetAllAuthors")
                .WithDisplayName("Authors")
                .WithTags("Authors")
                .Produces<List<AuthorGetDto>>()
                .Produces(500);

            endpoints.MapPost("/api/authors", async (AuthorDto authorDto) => await CreateAuthor(authorDto))
                .WithName("CreateAuthor")
                .WithDisplayName("Authors")
                .WithTags("Authors")
                .Produces<AuthorGetDto>(201)
                .Produces(500);

            endpoints.MapGet("api/authors/{id}", async (int id) => await GetAuthorById(id))
                .WithName("GetAuthorById")
                .WithDisplayName("Authors")
                .Produces<AuthorGetDto>()
                .Produces(404)
                .Produces(500);

            endpoints.MapPut("api/authors/{id}", async (int id, AuthorDto authorToUpdate) 
                => await UpdateAuthor(id, authorToUpdate))
                .WithName("UpdateAuthor")
                .WithDisplayName("Authors")
                .Produces(204)
                .Produces(500);

            endpoints.MapDelete("api/authors/{id}", async (int id) => await DeleteAuthor(id))
                .WithName("DeleteAuthor")
                .WithDisplayName("Authors")
                .Produces(204)
                .Produces(500);

            return endpoints;
        }

        public WebApplicationBuilder RegisterModule(WebApplicationBuilder builder)
        {
            var provider = builder.Services.BuildServiceProvider();
            _mediator = provider.GetRequiredService<IMediator>();
            _mapper = provider.GetRequiredService<IMapper>();
            return builder;
        }

        /// <summary>
        /// Gets all authors
        /// </summary>
        /// <returns></returns>
        private async Task<IResult> GetAllAuthors()
        {
            var authors = await _mediator.Send(new GetAllAuthorsQuery());
            return Results.Ok(authors);
        }

        /// <summary>
        /// Creates an author
        /// </summary>
        /// <param name="authorDto"></param>
        /// <returns></returns>
        private async Task<IResult> CreateAuthor(AuthorDto authorDto)
        {
            var command = new CreateAuthorCommand { Author = authorDto };
            var result = await _mediator.Send(command);
            return Results.CreatedAtRoute("GetAuthorById", new { Id = result.Id}, result);
        }

        private async Task<IResult> GetAuthorById(int id)
        {
            var result = await _mediator.Send(new GetAuthorById { AuthorId = id});
            if (result is null)
                return Results.NotFound();

            return Results.Ok(result);
        }

        private async Task<IResult> UpdateAuthor(int id, AuthorDto authorToUpdate)
        {
            var command = new UpdateAuthor
            {
                AuthorId = id,
                FirstName = authorToUpdate.FirstName,
                LastName = authorToUpdate.LastName,
                Bio = authorToUpdate.Bio,
                DateOfBirth = authorToUpdate.DateOfBirth
            };
            await _mediator.Send(command);

            return Results.NoContent();
        }

        private async Task<IResult> DeleteAuthor(int id)
        {
            await _mediator.Send(new DeleteAuthor { AuthorId = id});
            return Results.NoContent();
        }
    }
}
