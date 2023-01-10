using Bogus;
using Bogus.Extensions.Brazil;
using Fleet.Api.Models;

namespace Fleet.Api
{
    public class DbInitializer
	{
        private readonly ApplicationContext _context;

        public DbInitializer(ApplicationContext context)
		{
			_context = context;
        }

        public void Run()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            var brandFaker = new Faker<Brand>()
                .RuleFor(brand => brand.Name, value => value.Vehicle.Manufacturer());

            var modelFaker = new Faker<Model>()
                .RuleFor(model => model.Name, value => value.Vehicle.Model());

            var vehicleFaker = new Faker<Vehicle>()
                .RuleFor(vehicle => vehicle.CarrierDocumentNumber, value => value.Company.Cnpj())
                .RuleFor(vehicle => vehicle.LicensePlate, value => value.Vehicle.Vin());

            var brands = brandFaker.Generate(7);
            foreach (var brand in brands)
            {
                var models = modelFaker.GenerateBetween(3, 22);
                foreach (var model in models)
                {
                    var vehicles = vehicleFaker.GenerateBetween(10, 500);
                    model.Vehicles = vehicles;
                }
                brand.Models = models;
            }

            _context.Brand.AddRange(brands);
            _context.SaveChanges();
        }
	}
}

