using System.Linq;
using NHibernate.Playground.Domain;
using NHibernate.Playground.Repositories;
using NUnit.Framework;

namespace NHibernate.Playground.Specifications.MeasurementPoints.Forecasts
{
    [TestFixture]
    public class WhenANewForecastIsAddedToAMeasurementPoint
    {
        [Test]
        public void ItShouldBePossibleToLoadTheMeasurementPointAndItsNewlyCreatedForecast()
        {
            var measurementPointRepository = new MeasurementPointRepository();

            var measurementPoint = AddMeasurementPoint(measurementPointRepository);
            var model = AddForecastToMeasurementPoint(measurementPoint, measurementPointRepository);
            var persistedMeasurementPoint = measurementPointRepository.Load(measurementPoint.Id);

            Assert.That(persistedMeasurementPoint, Is.Not.Null);
            Assert.That(persistedMeasurementPoint.Forecasts, Is.Not.Null.And.Not.Empty, "There should be a forecast");
            Assert.That(persistedMeasurementPoint.Forecasts.First().Id, Is.EqualTo(measurementPoint.Forecasts.First().Id), "The forecast loaded should be the same as the one previously saved");
            Assert.That(persistedMeasurementPoint.Forecasts.All(x=>x.Model.Id == model.Id), Is.True, "The persisted forecast should have the assigned model");

            measurementPointRepository.Delete(measurementPoint);
        }

        [Test]
        public void ItShouldBePossibleToAlterTheForecast()
        {
            var measurementPointRepository = new MeasurementPointRepository();

            var measurementPoint = AddMeasurementPoint(measurementPointRepository);
            var model = AddForecastToMeasurementPoint(measurementPoint, measurementPointRepository);
            var persistedMeasurementPoint = measurementPointRepository.Load(measurementPoint.Id);
            var newModelId = 2;
            persistedMeasurementPoint.Forecasts.First().ChangeModel(new ModelRepository().Load(newModelId));

            Assert.That(persistedMeasurementPoint.Forecasts.First().Model.Id, Is.EqualTo(newModelId));            

            measurementPointRepository.Delete(measurementPoint);
        }

        private static MeasurementPoint AddMeasurementPoint(MeasurementPointRepository measurementPointRepository)
        {
            var measurementPoint = MeasurementPoint.CreateNew();
            measurementPointRepository.Save(measurementPoint);

            return measurementPoint;
        }

        private static Model AddForecastToMeasurementPoint(MeasurementPoint measurementPoint, MeasurementPointRepository measurementPointRepository)
        {
            var model = new ModelRepository().Load(1);
            measurementPoint.AddForeCast(usingModel: model);
            measurementPointRepository.Save(measurementPoint);

            return model;
        }
    }
}