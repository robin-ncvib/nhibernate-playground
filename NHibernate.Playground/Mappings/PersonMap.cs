using FluentNHibernate.Mapping;

using NHibernate.Playground.Domain;

namespace NHibernate.Playground.Mappings
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.PersonId).Column("PersonId").GeneratedBy.Assigned();
        }
    }
}