namespace Core.Entities
{
    public class PrivateOwnership : BaseOwnership
    {
        public int PrivateOwnerId { get; set; }
        public PrivateOwner PrivateOwner { get; set; }
    }
}