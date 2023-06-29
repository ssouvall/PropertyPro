using Core.Entities.Enums;

namespace Core.Entities
{
    public class Property : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public States State { get; set; }
        public string Zip { get; set; }
        public int PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; }   
        public int OwnershipTypeId { get; set; } 
        public OwnershipType OwnershipType { get; set; }
        private int? ownerId;
        private int? companyId;
        public int? OwnerId
        {
            get { return ownerId; }
            set
            {
                ownerId = value;
                companyId = null; // Nullify companyId when ownerId is set
            }
        }

        public int? CompanyId
        {
            get { return companyId; }
            set
            {
                companyId = value;
                ownerId = null; // Nullify ownerId when companyId is set
            }
        }
        private Owner owner;
        private Company company;

        public Owner Owner
        {
            get { return owner; }
            set
            {
                owner = value;
                company = null; // Ensure that the company is set to null when an owner is assigned
            }
        }

        public Company Company
        {
            get { return company; }
            set
            {
                company = value;
                owner = null; // Ensure that the owner is set to null when a company is assigned
            }
        }
        public ICollection<PropertyFile> PropertyImages { get; set; } = new List<PropertyFile>();
    }
}