using Core.Entities.Enums;

namespace Core.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public string EinNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public States State { get; set; }
        public string Zip { get; set; }
        public ICollection<CompanyOwnership> CompanyOwnerships { get; } = new List<CompanyOwnership>();
    }
}