using Codewrinkles.MinimalApi.SmartModules.Extensions.WebApplicationExtensions;
using Thoughtful.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationServices(builder);
builder.Services.AddSmartModules(typeof(Program));

var app = builder.Build();
app.ConfigureApplication();
app.UseSmartModules();

app.Run();
