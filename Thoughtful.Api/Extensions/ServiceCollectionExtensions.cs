using Thoughtful.Dal;

namespace Thoughtful.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new() { Title = builder.Environment.ApplicationName, Version="v1"});
                c.TagActionsBy(ta =>
                {
                    return new List<string> { ta.ActionDescriptor.DisplayName! };
                });
            });
            builder.Services.AddDbContext<ThoughtfulDbContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddMediatR(typeof(Program));
            builder.Services.AddAutoMapper(typeof(Program));
            return services;
        }
    }
}
