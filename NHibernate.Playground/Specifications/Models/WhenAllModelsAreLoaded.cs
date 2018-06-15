using NHibernate.Playground.Repositories;
using NUnit.Framework;

namespace NHibernate.Playground.Specifications.Models
{
    public class WhenAllModelsAreLoaded
    {
        [Test]
        public void AllModelsShouldBeAvalable()
        {
            ModelRepository repository = new ModelRepository();
            var models = repository.LoadAll();

            Assert.That(models.Count, Is.EqualTo(4));
        }
    }
}