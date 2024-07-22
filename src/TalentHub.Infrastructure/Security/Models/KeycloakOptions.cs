namespace TalentHub.Infrastructure.Security.Models;

internal sealed record KeycloakOptions(
    string AdminUrl,
    string TokenUrl,
    string AdminClientId,
    string AdminClientSecret,
    string AuthClientId,
    string AuthClientSecret)
{
    internal const string SectionName = "Keycloak";
}