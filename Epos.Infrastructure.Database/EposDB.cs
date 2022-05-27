using Epos.Domain.Map;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.Extensions.DependencyInjection;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Text;

namespace Epos.Infrastructure.Database
{

    public static class EposDB
    {
        public static IServiceCollection EposDatabaseConnection(this IServiceCollection services/*, IConfiguration cfg*/)
        {
            //string connectionString = cfg.GetConnectionString("DefaultConnection");
            string connectionString = "DatabaseConnection";

            var configuration = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(connectionString).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductMap>()
                                               .AddFromAssemblyOf<CategoryMap>()
                )
                .ExposeConfiguration(config => new SchemaExport(config).Create(false, false));

            var sessionFactory = configuration.BuildSessionFactory();

            services.AddSingleton(sessionFactory);
            services.AddScoped(factory => sessionFactory.OpenSession());

            return services;
        }
    }
}
