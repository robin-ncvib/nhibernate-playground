using NHibernate.Playground.Repositories;
using NUnit.Framework;

namespace NHibernate.Playground.Specifications.Models
{
    public class WhenASingleModelIsLoaded
    {
        [Test]
        public void TheSingleModelShouldBeAvailable()
        {
            ModelRepository repository = new ModelRepository();
            var id = 1;
            var model = repository.Load(id);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.Id, Is.EqualTo(id));
        }
    }
}