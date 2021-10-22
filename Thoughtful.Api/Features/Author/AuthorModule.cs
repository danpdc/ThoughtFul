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
            endpoints.MapGet("/api/authors", async (ThoughtfulDbContext ctx) =>
            {
                return await _mediator.Send(new GetAllAuthorsQuery());
            })
            .WithName("GetWeatherForecast");

            endpoints.MapPost("/api/authors", async (ThoughtfulDbContext ctx, AuthorDto authorDto) => {
                var command = new CreateAuthorCommand { Author = authorDto};
                return await _mediator.Send(command);
            });

            return endpoints;
        }

        public WebApplicationBuilder RegisterModule(WebApplicationBuilder builder)
        {
            var provider = builder.Services.BuildServiceProvider();
            _mediator = provider.GetRequiredService<IMediator>();
            _mapper = provider.GetRequiredService<IMapper>();
            return builder;
        }
    }
}
