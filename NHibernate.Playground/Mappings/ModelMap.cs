using FluentNHibernate.Mapping;
using NHibernate.Playground.Domain;

namespace NHibernate.Playground.Mappings
{
    public class ModelMap : ClassMap<Model>
    {
        public ModelMap()
        {
            Id(x => x.Id).Column("ModelId").GeneratedBy.Assigned();
        }
    }
}