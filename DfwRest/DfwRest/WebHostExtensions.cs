using DfwRest.Repo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DfwRest
{
    public static class WebHostExtensions
    {
        public static IWebHost SeedData(this IWebHost host)
        {
            using var scope = host.Services.CreateScope();

            var context = scope.ServiceProvider.GetService<WordContext>();

            new ContextSeeder(context).Seed();

            return host;
        }
    }
}