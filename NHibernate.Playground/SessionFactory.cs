using System;

using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;

using NHibernate.Playground.Domain.Inspection;
using NHibernate.Playground.Mappings.Inspection;
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
            return Fluently
                .Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString("Data Source=localhost;Database=NHibernatePlayground;Trusted_Connection=True;").ShowSql())
                .Mappings(
                    m =>
                        {
                            m.FluentMappings.AddFromAssemblyOf<AssemblyToken>();
                            m.AutoMappings.Add(CreateInspectionAutoMappings());
                        });
        }

        private static AutoPersistenceModel CreateInspectionAutoMappings()
        {
            var besiktningConfiguration = new InspectionConfiguration();
            var besiktningModel =
                AutoMap
                    .AssemblyOf<AssemblyToken>(besiktningConfiguration)
                    .UseOverridesFromAssemblyOf<AssemblyToken>()
                    .Conventions.Add(new EnumConvention());

            return besiktningModel;
        }
    }
}