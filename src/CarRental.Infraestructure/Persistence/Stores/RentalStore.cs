using CarRental.Application.Interfaces.Stores;

namespace CarRental.Infraestructure.Persistence.Stores;

public class RentalStore : StoreBase<Rental>, IRentalStore
{
    public RentalStore(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}