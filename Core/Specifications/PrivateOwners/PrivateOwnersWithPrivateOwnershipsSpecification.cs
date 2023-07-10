using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications.PrivateOwners
{
    public class PrivateOwnersWithPrivateOwnershipsSpecification : BaseSpecification<PrivateOwner>
    {
        public PrivateOwnersWithPrivateOwnershipsSpecification()
        {
            AddInclude(x => x.PrivateOwnerships);
        }

        public PrivateOwnersWithPrivateOwnershipsSpecification(int id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.PrivateOwnerships);
        }
    }
}