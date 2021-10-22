using Thoughtful.Dal;
using Thoughtful.Domain.Model;

namespace Thoughtful.Api.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication ConfigureApplication(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            return app;
        }        
    }
}
