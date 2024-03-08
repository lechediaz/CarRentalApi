using CarRental.Application.Interfaces.Stores;

namespace CarRental.Infraestructure.Persistence.Stores;

public class LocationStore : StoreBase<Location>, ILocationStore
{
    public LocationStore(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}