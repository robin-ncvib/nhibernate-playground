using System;
using System.Xml.Serialization;

namespace NHibernate.Playground.TypedIdentifiers
{
    public class Id<T>
    {
        public Id()
            : this(Guid.NewGuid())
        {
        }

        public Id(Id<T> id)
            : this(id.Value)
        {
        }

        public Id(Guid id)
        {
            DomainType = typeof(T);
            Value = id;
        }

        [XmlAttribute]
        public Guid Value { get; set; }

        [XmlIgnore]
        public System.Type DomainType { get; set; }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}