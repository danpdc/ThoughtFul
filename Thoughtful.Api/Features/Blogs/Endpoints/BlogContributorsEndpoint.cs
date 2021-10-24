namespace Thoughtful.Api.Features.Blogs.Endpoints
{
    public class BlogContributorsEndpoint : IEndpoint
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public BlogContributorsEndpoint(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        public IEndpointRouteBuilder RegisterRoutes(IEndpointRouteBuilder endpoints)
        {
            return endpoints;
        }
    }
}
