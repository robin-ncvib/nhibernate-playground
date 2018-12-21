using System.Linq;

using NHibernate.Playground.Domain.Inspection;

using NUnit.Framework;

namespace NHibernate.Playground.Specifications.Inspections
{
    [TestFixture]
    public class LoadPostInspections
    {
        [Test]
        public void VerifyPostInspectionsExist()
        {
            var sessionFactory = SessionFactory.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var postInspections = session.Query<PostInspection>().ToList();
                Assert.That(postInspections, Is.Not.Empty);
            }
        }
    }
}