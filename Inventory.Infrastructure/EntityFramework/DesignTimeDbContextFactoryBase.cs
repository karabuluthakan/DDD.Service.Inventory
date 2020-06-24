using System;
using System.IO;
using Inventory.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Inventory.Infrastructure.EntityFramework
{
    public abstract class DesignTimeDbContextFactoryBase<TContext> :
        IDesignTimeDbContextFactory<TContext> where TContext : DbContext
    {
        private const string ConnectionStringName = DefaultConstants.DefaultDatabaseConnection;
        private const string AspNetCoreEnvironment = DefaultConstants.AspNetCoreEnvironment;

        public TContext CreateDbContext(string[] args)
        {
            var basePath = Directory.GetCurrentDirectory()
                           + string.Format("{0}..{0}" + DefaultConstants.DbConnectionDirectory,
                               Path.DirectorySeparatorChar);
            return Create(basePath, Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
        }

        protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

        private TContext Create(string basePath, string environmentName)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(DefaultConstants.AppSettingsJson)
                .AddJsonFile($"appsettings.Development.json", optional: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString(ConnectionStringName);

            return Create(connectionString);
        }

        private TContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.",
                    nameof(connectionString));
            }

            Console.WriteLine($"Trying to connect with this connection string: '{connectionString}'.");

            var optionsBuilder = new DbContextOptionsBuilder<TContext>();

            optionsBuilder.UseSqlite(connectionString);

            return CreateNewInstance(optionsBuilder.Options);
        }
    }
}