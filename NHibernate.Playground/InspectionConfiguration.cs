using FluentNHibernate.Automapping;

namespace NHibernate.Playground
{
    public class InspectionConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(System.Type type)
        {
            return type.Namespace.StartsWith("NHibernate.Playground.Domain.Inspection");
        }

        public override bool IsComponent(System.Type type)
        {
            return base.IsComponent(type);
        }
    }
}