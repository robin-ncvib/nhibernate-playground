using NHibernate.Playground.Domain;
using NHibernate.Playground.Repositories;
using NUnit.Framework;

namespace NHibernate.Playground.Specifications.MeasurementPoints
{
    public class WhenANewMeasurementPointIsSaved
    {
        [Test]
        public void TheMeasurmentPointPersistedShouldHaveTheSameDataAsTheMeasurementPointBeingSaved()
        {
            var measurementPointRepository = new MeasurementPointRepository();
            var newMeasurementPoint = MeasurementPoint.CreateNew();
            measurementPointRepository.Save(newMeasurementPoint);
            var persistedMeasuementPoint = measurementPointRepository.Load(newMeasurementPoint.Id);

            Assert.That(persistedMeasuementPoint, Is.Not.Null);
            Assert.That(persistedMeasuementPoint.Id, Is.EqualTo(newMeasurementPoint.Id));
            Assert.That(persistedMeasuementPoint.CreatedDate, Is.EqualTo(newMeasurementPoint.CreatedDate));
            Assert.That(persistedMeasuementPoint.IsActive, Is.EqualTo(newMeasurementPoint.IsActive));
            Assert.That(persistedMeasuementPoint.Forecasts, Is.Empty);

            measurementPointRepository.Delete(newMeasurementPoint);
        }
    }
}