using FluentNHibernate.Mapping;
using NHibernate.Playground.Domain;

namespace NHibernate.Playground.Mappings
{
    public class MeasurementPointMap : ClassMap<MeasurementPoint>
    {
        public MeasurementPointMap()
        {
            Id(x => x.Id).Column("MeasurementPointId").GeneratedBy.Assigned();
            Map(x => x.CreatedDate);
            Map(x => x.IsActive);
            HasMany(x => x.Forecasts).KeyColumn("MeasurementPointId").Cascade.AllDeleteOrphan().Inverse();
        }
    }
}