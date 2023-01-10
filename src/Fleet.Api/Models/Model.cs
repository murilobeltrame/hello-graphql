using System.ComponentModel.DataAnnotations;

namespace Fleet.Api.Models
{
    public class Model
	{
		public int Id { get; set; }
		[MaxLength(20)]
		public string Name { get; set; }
		public ICollection<Vehicle> Vehicles { get; set; }
	}
}
