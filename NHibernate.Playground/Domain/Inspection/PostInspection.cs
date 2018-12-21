using System;
using System.Collections.Generic;

namespace NHibernate.Playground.Domain.Inspection
{
    public class PostInspection
    {
        public virtual Guid PostInspectionId { get; set; }
        public virtual string Name { get; set; }

        public virtual Person ContactPerson { get; set; }
        public virtual IList<PostInspectionPerson> Inspectors { get; set; }
    }
}