using System.Collections.Generic;
using System.Linq;
using NHibernate.Playground.Domain;

namespace NHibernate.Playground.Repositories
{
    public class ModelRepository
    {
        public Model Load(int id)
        {
            var sessionFactory = SessionFactory.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                return session.Query<Model>().Single(m => m.Id == id);
            }
        }

        public List<Model> LoadAll()
        {
            var sessionFactory = SessionFactory.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    return session.Query<Model>().ToList();
                }
            }
        }
    }
}