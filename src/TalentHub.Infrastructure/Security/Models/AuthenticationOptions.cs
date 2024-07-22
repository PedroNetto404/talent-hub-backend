namespace TalentHub.Infrastructure.Security.Models;

internal sealed record AuthenticationOptions(
    string Audience,
    string MetadataUrl,
    bool RequireHttpsMetadata,
    string Issuer
)
{
    internal const string SectionName = "Authentication";
}