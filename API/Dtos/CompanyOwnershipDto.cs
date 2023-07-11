namespace API.Dtos
{
    public class CompanyOwnershipDto
    {
        public int Id { get; set; }
        public PropertyDto Property { get; set; }
        public CompanyOwnerDto CompanyOwner { get; set; }
    }
}