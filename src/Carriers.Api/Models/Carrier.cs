using System.ComponentModel.DataAnnotations;

namespace Carriers.Api.Models
{
    public class Carrier
	{
		public int Id { get; set; }
		[MaxLength(50)]
		public string Name { get; set; }
		[MaxLength(15)]
		public string DocumentNumber { get; set; }
		[MaxLength(100)]
		public string Address { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(20)]
        public string State { get; set; }
        [MaxLength(20)]
        public string Country { get; set; }
		[MaxLength(8)]
		public string ZipCode { get; set; }
	}
}

