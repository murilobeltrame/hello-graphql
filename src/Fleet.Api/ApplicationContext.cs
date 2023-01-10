using Microsoft.EntityFrameworkCore;
using Fleet.Api.Models;

namespace Fleet.Api
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> context) : base(context) { }

        public DbSet<Brand> Brand { get; set; } = default!;

        public DbSet<Model> Model { get; set; } = default!;

        public DbSet<Vehicle> Vehicle { get; set; } = default!;
    }
}