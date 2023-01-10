using System.ComponentModel.DataAnnotations;

namespace Carriers.Api.Models
{
    public class CarrierGroup
	{
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Carrier> Carriers { get; set; }
    }
}
