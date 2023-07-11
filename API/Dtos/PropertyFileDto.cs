namespace API.Dtos
{
    public class PropertyFileDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
        public int FileSize { get; set; }
    }
}