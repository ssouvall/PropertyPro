namespace API.Dtos
{
    public class CompanyOwnerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EinNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }      
        public IReadOnlyList<CompanyOwnershipDto> CompanyOwnerships { get; set; }
    }
}