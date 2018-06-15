using System;

namespace NHibernate.Playground.Domain
{
    public class Forecast
    {
        protected Forecast() { }

        public virtual Guid Id { get; protected set; }

        public virtual Model Model { get; protected set; }
        public virtual MeasurementPoint MeasurementPoint { get; protected set; }

        public static Forecast CreateNew(MeasurementPoint measurementPoint, Model model)
        {
            return new Forecast
            {
                Id = Guid.NewGuid(),
                MeasurementPoint = measurementPoint,
                Model = model
            };
        }

        public virtual void ChangeModel(Model newModel)
        {
            Model = newModel;
        }
    }
}