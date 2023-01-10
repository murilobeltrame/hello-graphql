using System.ComponentModel.DataAnnotations;

namespace Fleet.Api.Models
{
    public class Vehicle
	{
		public int Id { get; set; }
		[MaxLength(7)]
		public string LicensePlate { get; set; }
		[MaxLength(15)]
		public string? CarrierDocumentNumber { get; set; }
	}
}

