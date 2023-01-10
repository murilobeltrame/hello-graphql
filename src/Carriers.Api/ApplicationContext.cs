using Microsoft.EntityFrameworkCore;
using Carriers.Api.Models;

namespace Carriers.Api
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> context) : base(context) { }
        public DbSet<Carriers.Api.Models.Carrier> Carrier { get; set; } = default!;
        public DbSet<Carriers.Api.Models.CarrierGroup> CarrierGroup { get; set; } = default!;
    }
}
