using Microsoft.EntityFrameworkCore;

namespace TalentHub.Infrastructure.Persistence;

internal sealed class TalentHubDbContext(
    DbContextOptions<TalentHubDbContext> options
) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TalentHubDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}