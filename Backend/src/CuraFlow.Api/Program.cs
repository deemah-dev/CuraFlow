using CuraFlow.Api;
using CuraFlow.Application;
using CuraFlow.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddPresentation(builder.Configuration);

var app = builder.Build();

app.Run();
