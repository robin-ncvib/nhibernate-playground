using System;

using NHibernate.Playground.Domain;

namespace NHibernate.Playground.TypedIdentifiers
{
    public class MeasurementPointId : Id<MeasurementPoint>
    {
        private MeasurementPointId() : base(Guid.NewGuid())
        {
        }

        public static MeasurementPointId NewId()
        {
            return new MeasurementPointId();
        }
    }
}