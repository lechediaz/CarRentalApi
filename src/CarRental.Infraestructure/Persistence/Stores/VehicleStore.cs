using CarRental.Application.Interfaces.Stores;

namespace CarRental.Infraestructure.Persistence.Stores;

public class VehicleStore : StoreBase<Vehicle>, IVehicleStore
{
    public VehicleStore(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}