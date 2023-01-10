using GraphQl.Api.Services;

namespace GraphQl.Api.Queries
{
    public class Query
    {
        public Task<ICollection<Brand>> GetBrandsAsync(
            [Service] FleetService service,
            CancellationToken cancellationToken)
        {
            return service.BrandsAllAsync(cancellationToken);
        }

        public Task<Brand> GetBrandByIdAsync(
            [Service] FleetService service,
            int id,
            CancellationToken cancellationToken)
        {
            return service.BrandsGETAsync(id, cancellationToken);
        }
    }
}

