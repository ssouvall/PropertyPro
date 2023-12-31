using Core.Entities;

namespace Core.Specifications.Ownerships
{
    public class PrivateOwnershipsWithPrivateOwnersSpecification : BaseSpecification<PrivateOwnership>
    {
        public PrivateOwnershipsWithPrivateOwnersSpecification()
        {
            AddInclude(x => x.PrivateOwner);
            AddInclude(x => x.Property);
        }

        public PrivateOwnershipsWithPrivateOwnersSpecification(int id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.PrivateOwner);
            AddInclude(x => x.Property);
        }
    }
}