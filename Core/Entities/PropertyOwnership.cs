namespace Core.Entities
{
    public class PropertyOwnership : BaseEntity
    {
        public int PropertyOwnershipTypeId { get; set; }
        public PropertyOwnershipType PropertyOwnershipType { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}