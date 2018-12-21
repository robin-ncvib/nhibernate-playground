using System;

namespace NHibernate.Playground.Domain
{
    public class Person
    {
        public virtual Guid PersonId { get; set; }
        public virtual string Name { get; set; }
    }
}