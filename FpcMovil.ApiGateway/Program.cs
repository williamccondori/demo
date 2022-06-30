using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var ocelotConfiguration = new ConfigurationBuilder();
ocelotConfiguration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOcelot(ocelotConfiguration.Build());

var app = builder.Build();
app.UseOcelot().Wait();
app.Run();