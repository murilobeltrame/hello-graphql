using Bogus;
using Bogus.Extensions.Brazil;
using Carriers.Api.Models;

namespace Carriers.Api
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

            var carrierFaker = new Faker<Carrier>()
                .RuleFor(carrier => carrier.Address, value => value.Address.StreetAddress())
                .RuleFor(carrier => carrier.City, value => value.Address.City())
                .RuleFor(carrier => carrier.Country, value => value.Address.Country())
                .RuleFor(carrier => carrier.DocumentNumber, value => value.Company.Cnpj())
                .RuleFor(carrier => carrier.Name, value => value.Company.CompanyName())
                .RuleFor(carrier => carrier.State, value => value.Address.State())
                .RuleFor(carrier => carrier.ZipCode, value => value.Address.ZipCode());

            var carrierGroupFaker = new Faker<CarrierGroup>()
                .RuleFor(carrierGroup => carrierGroup.Name, value => value.Company.CompanyName());

            var carrierGroups = carrierGroupFaker.GenerateBetween(100, 200);
            foreach (var carrierGroup in carrierGroups)
            {
                var carriers = carrierFaker.GenerateBetween(1, 20);
                carrierGroup.Carriers = carriers;
            }

            _context.CarrierGroup.AddRange(carrierGroups);
            _context.SaveChanges();
        }
    }
}
