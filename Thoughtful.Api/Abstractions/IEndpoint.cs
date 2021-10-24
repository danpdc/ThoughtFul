namespace Thoughtful.Api.Abstractions
{
    public interface IEndpoint
    {
        IEndpointRouteBuilder RegisterRoutes(IEndpointRouteBuilder endpoints);
    }
}
