using TalentHub.Application.Extensions;
using TalentHub.Domain.Extensions;
using TalentHub.Infrastructure.Extensions;
using TalentHub.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddDomainServices()
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddPresentationServices();

await builder
    .Build()
    .UsePipeline(builder.Environment)
    .RunAsync();