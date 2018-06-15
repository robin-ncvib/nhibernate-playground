using System;
using System.Collections.Generic;

namespace NHibernate.Playground.Domain
{
    public class MeasurementPoint
    {
        protected MeasurementPoint() { }

        public virtual Guid Id { get; protected set; }
        public virtual bool IsActive { get; protected set; }
        public virtual DateTimeOffset CreatedDate { get; protected set; }

        public virtual IList<Forecast> Forecasts { get; protected set; } = new List<Forecast>();

        public static MeasurementPoint CreateNew()
        {
            var measurementPoint = 
                new MeasurementPoint
                {
                    Id = Guid.NewGuid(),
                    IsActive = true,
                    CreatedDate = DateTimeOffset.Now
                };

            return measurementPoint;
        }

        public virtual void Inactivate()
        {
            IsActive = false;
        }

        public virtual void AddForeCast(Model usingModel)
        {
            var newForecast = Forecast.CreateNew(this, usingModel);
            Forecasts.Add(newForecast);
        }
    }
}