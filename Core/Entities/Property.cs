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
        public int PropertyOwnershipStructureId { get; set; }
        public PropertyOwnershipStructure PropertyOwnershipStructure { get; set; }
        public ICollection<PropertyFile> PropertyImages { get; set; } = new List<PropertyFile>();
    }
}