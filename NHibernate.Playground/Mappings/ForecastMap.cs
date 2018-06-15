using FluentNHibernate.Mapping;
using NHibernate.Playground.Domain;

namespace NHibernate.Playground.Mappings
{
    public class ForecastMap : ClassMap<Forecast>
    {
        public ForecastMap()
        {
            Id(x => x.Id).Column("ForecastId").GeneratedBy.Assigned();

            References(x => x.Model).Column("ModelId");
            References(x => x.MeasurementPoint).Column("MeasurementPointId");
        }
    }
}