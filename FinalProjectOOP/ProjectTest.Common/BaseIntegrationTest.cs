using Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using ProjectTest.Common;
using Xunit;

public class BaseIntegrationTest : IClassFixture<IntegrationTestHostFactory>
{
    protected readonly ApplicationDbContext Context;

    protected BaseIntegrationTest(IntegrationTestHostFactory factory)
    {
        var host = factory.CreateHost(); 
        var scope = host.Services.CreateScope(); 
        Context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>(); 
    }

    protected async Task<int> SaveChangesAsync()
    {
        var result = await Context.SaveChangesAsync();
        Context.ChangeTracker.Clear();
        return result;
    }
}