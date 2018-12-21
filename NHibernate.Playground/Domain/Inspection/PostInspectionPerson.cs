using System;

namespace NHibernate.Playground.Domain.Inspection
{
    //public class PostInspectionPerson
    //{
    //    public virtual Guid PostInspectionId { get; set; }
    //    public virtual Guid PersonId { get; set; }

    //    public override bool Equals(object obj)
    //    {
    //        if (!(obj is PostInspectionPerson other))
    //        {
    //            return false;
    //        }

    //        if (ReferenceEquals(this, other))
    //        {
    //            return true;
    //        }

    //        return PostInspectionId == other.PostInspectionId &&
    //               PersonId == other.PersonId;
    //    }

    //    public override int GetHashCode()
    //    {
    //        unchecked
    //        {
    //            int hash = GetType().GetHashCode();
    //            hash = (hash * 31) ^ PostInspectionId.GetHashCode();
    //            hash = (hash * 31) ^ PersonId.GetHashCode();

    //            return hash;
    //        }
    //    }
    //}
}