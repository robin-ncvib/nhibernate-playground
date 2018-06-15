using System;
using System.Linq;
using NHibernate.Linq;
using NHibernate.Playground.Domain;

namespace NHibernate.Playground.Repositories
{
    public class MeasurementPointRepository
    {
        public MeasurementPoint Load(Guid id)
        {
            var sessionFactory = SessionFactory.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                return 
                    session
                        .Query<MeasurementPoint>()
                        .FetchMany(x=>x.Forecasts)
                        .Single(m => m.Id == id);
            }
        }

        public void Save(MeasurementPoint measurementPoint)
        {
            var sessionFactory = SessionFactory.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.SaveOrUpdate(measurementPoint);
                transaction.Commit();
            }
        }

        public void Delete(MeasurementPoint measurementPoint)
        {
            var sessionFactory = SessionFactory.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(measurementPoint);
                transaction.Commit();
            }
        }
    }
}