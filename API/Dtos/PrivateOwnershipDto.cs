namespace API.Dtos
{
    public class PrivateOwnershipDto
    {
        public int Id { get; set; }
        public PropertyDto Property { get; set; }
        public PrivateOwnerDto PrivateOwner { get; set; }
    }
}