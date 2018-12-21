namespace NHibernate.Playground.Domain.Inspection
{
    public class PostInspectionPerson
    {
        public virtual PostInspection PostInspection { get; set; }
        public virtual Person Person { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is PostInspectionPerson other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return PostInspection.PostInspectionId == other.PostInspection.PostInspectionId &&
                   Person.PersonId == other.Person.PersonId;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = GetType().GetHashCode();
                hash = (hash * 31) ^ PostInspection.PostInspectionId.GetHashCode();
                hash = (hash * 31) ^ Person.PersonId.GetHashCode();

                return hash;
            }
        }
    }
}