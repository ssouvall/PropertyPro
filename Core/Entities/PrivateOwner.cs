using Core.Entities.Enums;

namespace Core.Entities
{
    public class PrivateOwner : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public States State { get; set; }
        public string Zip { get; set; }
        public virtual ICollection<PrivateOwnership> PrivateOwnerships { get; } = new List<PrivateOwnership>();
    }
}