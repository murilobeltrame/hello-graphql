using System.ComponentModel.DataAnnotations;

namespace Fleet.Api.Models
{
    public class Brand
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }
    }
}