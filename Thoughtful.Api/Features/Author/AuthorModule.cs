using Microsoft.AspNetCore.Authorization;
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
                .Produces<AuthorGetDto>()
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
            return Results.Ok(result);
        }
    }
}
