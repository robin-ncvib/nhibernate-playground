using NHibernate.Playground.Domain;
using NHibernate.Playground.Repositories;
using NUnit.Framework;

namespace NHibernate.Playground.Specifications.MeasurementPoints
{
    public class WhenAnInactivatedMeasurementPointIsSaved
    {     
        [Test]
        public void TheMeasurmentPointPersistedShouldBeInactive()
        {
            var measurementPointRepository = new MeasurementPointRepository();
            var aPreviouslySavedMeasurementPoint = LoadAPreviouslySavedMeasurementPoint(measurementPointRepository);

            aPreviouslySavedMeasurementPoint.Inactivate();
            measurementPointRepository.Save(aPreviouslySavedMeasurementPoint);
            var alteredAndPersistedMeasuementPoint = measurementPointRepository.Load(aPreviouslySavedMeasurementPoint.Id);

            Assert.That(alteredAndPersistedMeasuementPoint.IsActive, Is.EqualTo(false));

            measurementPointRepository.Delete(aPreviouslySavedMeasurementPoint);
        }

        private static MeasurementPoint LoadAPreviouslySavedMeasurementPoint(MeasurementPointRepository measurementPointRepository)
        {
            var newMeasurementPoint = MeasurementPoint.CreateNew();
            measurementPointRepository.Save(newMeasurementPoint);
            return measurementPointRepository.Load(newMeasurementPoint.Id);           
        }
    }
}