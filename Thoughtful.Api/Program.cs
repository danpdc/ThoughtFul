using Thoughtful.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationServices(builder);
builder.RegisterModules();

var app = builder.Build();
app.ConfigureApplication();
app.MapEndpoints();

app.Run();
