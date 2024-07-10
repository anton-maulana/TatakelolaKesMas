// ---------------------------------------
// Email: quickapp@ebenmonney.com
// Templates: www.ebenmonney.com/templates
// (c) 2024 www.ebenmonney.com/mit-license
// ---------------------------------------

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TatakelolaKesMas.Core.Infrastructure;
using TatakelolaKesMas.Server.Services;
using TatakelolaKesMas.Services;

namespace TatakelolaKesMas.Server.Configuration
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

            builder.UseNpgsql(configuration["ConnectionStrings:DefaultConnection"],
                    b => b.MigrationsAssembly(migrationsAssembly))
                .UseLazyLoadingProxies();
            builder.UseOpenIddict();

            return new ApplicationDbContext(builder.Options, SystemUserIdAccessor.GetNewAccessor());
        }
    }
}
