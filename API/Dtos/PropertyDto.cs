namespace API.Dtos
{
    public class PropertyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PropertyType { get; set; }
        public int ManagementCompanyId { get; set; }
        public string ManagementCompanyName { get; set; }
        public IReadOnlyList<PropertyFileDto> PropertyImages { get; set; }
        public IReadOnlyList<CompanyOwnershipDto> CompanyOwnerships { get; set; }
        public IReadOnlyList<PrivateOwnershipDto> PrivateOwnerships { get; set; }
    }
}