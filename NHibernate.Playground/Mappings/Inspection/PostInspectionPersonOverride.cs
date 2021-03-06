﻿using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

using NHibernate.Playground.Domain.Inspection;

namespace NHibernate.Playground.Mappings.Inspection
{
    public class PostInspectionPersonOverride : IAutoMappingOverride<PostInspectionPerson>
    {       
        public void Override(AutoMapping<PostInspectionPerson> mapping)
        {
            mapping.Schema("Inspection");
            mapping.CompositeId()                
                .KeyReference(x => x.PostInspection, "PostInspectionId")
                .KeyReference(x => x.Person, "PersonId");
        }
    }
}