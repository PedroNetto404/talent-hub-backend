using TalentHub.Application.Extensions;
using TalentHub.Domain.Extensions;
using TalentHub.Infrastructure.Extensions;
using TalentHub.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddDefinedServices()
    .AddPresentationServices()
    .AddDomainServices()
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);

await builder
    .Build()
    .AddPipeline(builder.Environment)
    .RunAsync();

