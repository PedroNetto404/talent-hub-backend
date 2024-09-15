using TalentHub.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddWeb();

await builder
    .Build()
    .UsePipeline()
    .RunAsync();