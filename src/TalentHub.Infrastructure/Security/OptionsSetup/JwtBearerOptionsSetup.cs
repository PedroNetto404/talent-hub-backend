using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using TalentHub.Infrastructure.Security.Models;

namespace TalentHub.Infrastructure.Security.OptionsSetup;

internal sealed class JwtBearerOptionsSetup(
    IOptions<AuthenticationOptions> authOptions
) : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly AuthenticationOptions _authOptions = authOptions.Value;

    public void Configure(JwtBearerOptions options)
    {
        options.Audience = _authOptions.Audience;
        options.MetadataAddress = _authOptions.MetadataUrl;
        options.RequireHttpsMetadata = _authOptions.RequireHttpsMetadata;
        options.TokenValidationParameters.ValidIssuer = _authOptions.Issuer;
    }

    public void Configure(string? name, JwtBearerOptions options) => Configure(options);
}