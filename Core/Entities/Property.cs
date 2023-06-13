using Core.Entities.Enums;

namespace Core.Entities
{
    public class Property
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public States State { get; set; }
        public string Zip { get; set; }
    }
}