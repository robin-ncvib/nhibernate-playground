using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;

namespace NHibernate.Playground
{
    public class SessionFactory
    {
        public static ISessionFactory CreateSessionFactory( bool exposeSchema = false)
        {
            try
            {
                if(exposeSchema)
                {
                    return CreateFluentConfiguration()
                    .ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false))
                    .BuildSessionFactory();
                }

                return CreateFluentConfiguration().BuildSessionFactory();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static FluentConfiguration CreateFluentConfiguration()
        {
            void Mappings(MappingConfiguration m) => m.FluentMappings.AddFromAssemblyOf<AssemblyToken>();

            return Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString("Data Source=localhost;Database=NHibernatePlayground;Trusted_Connection=True;").ShowSql())
                .Mappings(Mappings);
        }      
    }
}