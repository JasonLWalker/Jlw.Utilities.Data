using System.Data;
using System.Data.Common;
using Jlw.Utilities.Data.DbUtility;
using Microsoft.Extensions.DependencyInjection;

namespace Jlw.Extensions.ModularDbClient
{
    public static partial class ModularDbClientExtensions
    {
		public static IServiceCollection AddModularDbClient<TConnection, TCommand, TParam, TConnBuilder>(this IServiceCollection services, string? connectionString = null, IModularDbClient<TConnection, TCommand, TParam, TConnBuilder>? dbClient = null, int commandTimeout = 30)
            where TConnection : IDbConnection, new()
            where TCommand : IDbCommand, new()
            where TParam : IDbDataParameter, new()
            where TConnBuilder : DbConnectionStringBuilder, new()
        {
            dbClient ??= new ModularDbClient<TConnection, TCommand, TParam, TConnBuilder>() { CommandTimeout = commandTimeout };
            services.AddSingleton<IModularDbClient>(dbClient);
            if (!string.IsNullOrWhiteSpace(connectionString)) services.AddSingleton<IModularDbOptions>(new ModularDbOptions() { ConnectionString = connectionString, DbClient = dbClient, CommandTimeout = dbClient.CommandTimeout});
            return services;
        }

        public static IServiceCollection AddModularDbClient<TConnection, TCommand, TParam>(this IServiceCollection services, string? connectionString = null, IModularDbClient? dbClient = null, int commandTimeout = 30)
            where TConnection : IDbConnection, new()
            where TCommand : IDbCommand, new()
            where TParam : IDbDataParameter, new()
        {
            dbClient ??= new ModularDbClient<TConnection, TCommand, TParam>() { CommandTimeout = commandTimeout };
            services.AddSingleton<IModularDbClient>(dbClient);
            if (!string.IsNullOrWhiteSpace(connectionString)) services.AddSingleton<IModularDbOptions>(new ModularDbOptions() { ConnectionString = connectionString, DbClient = dbClient, CommandTimeout = dbClient.CommandTimeout });
            return services;
        }

        public static IServiceCollection AddModularDbClient<TConnection>(this IServiceCollection services, string? connectionString = null, IModularDbClient? dbClient = null, int commandTimeout = 30)
            where TConnection : IDbConnection, new()
        {
            dbClient ??= new ModularDbClient<TConnection>(){CommandTimeout = commandTimeout};
            services.AddSingleton<IModularDbClient>(dbClient);
            if (!string.IsNullOrWhiteSpace(connectionString)) services.AddSingleton<IModularDbOptions>(new ModularDbOptions() { ConnectionString = connectionString, DbClient = dbClient, CommandTimeout = dbClient.CommandTimeout });
            return services;
        }

    }
}