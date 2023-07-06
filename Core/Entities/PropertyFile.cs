using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Core.Entities
{
    public class PropertyFile : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
        public int FileSize { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }
    }
}