namespace API.Dtos
{
    public class PrivateOwnerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public IReadOnlyList<PrivateOwnershipDto> PrivateOwnerships { get; set; }
    }
}