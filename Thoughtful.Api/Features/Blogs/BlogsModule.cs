using Codewrinkles.MinimalApi.SmartModules;
using Microsoft.Extensions.Logging;
using Thoughtful.Api.Features.Blogs.Endpoints;

namespace Thoughtful.Api.Features.Blogs
{
    public class BlogsModule : IModule
    {
        private readonly ILogger<BlogsModule> _logger;
        private readonly BlogReadsEndpoint _blogReadsEndpoint;
        private readonly BlogsWritesEndpoint _blogWritesEndpoint;
        public BlogsModule(ILogger<BlogsModule> logger, BlogReadsEndpoint blogReads,
            BlogsWritesEndpoint blogWrites)
        {
            _logger = logger;
            _blogReadsEndpoint = blogReads;
            _blogWritesEndpoint = blogWrites;
        }
        public IEndpointRouteBuilder MapEndpointDefinitions(IEndpointRouteBuilder endpoints)
        {
            _blogReadsEndpoint.RegisterRoutes(endpoints);
            _blogWritesEndpoint.RegisterRoutes(endpoints);
            return endpoints;
        }
    }
}
