using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

using NHibernate.Playground.Domain.Inspection;

namespace NHibernate.Playground.Mappings.Inspection
{
    public class PostInspectionOverride : IAutoMappingOverride<PostInspection>
    {
        public void Override(AutoMapping<PostInspection> mapping)
        {
            mapping.Schema("Inspection");
            mapping.Id(x => x.PostInspectionId).Column("PostInspectionId").GeneratedBy.Assigned();
            mapping.References(x => x.ContactPerson).Column("ContactPersonId").NotFound.Ignore();
            //mapping.HasManyToMany(x => x.Inspectors).NotFound.Ignore();
        }
    }
}