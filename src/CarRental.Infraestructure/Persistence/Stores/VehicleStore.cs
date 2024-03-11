using CarRental.Application.Interfaces.Stores;
using CarRental.Domain.Dtos;

namespace CarRental.Infraestructure.Persistence.Stores;

public class VehicleStore : StoreBase<Vehicle>, IVehicleStore
{
    public VehicleStore(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<Vehicle>> ListRentableVehiclesAsync(RentingFilters filters)
    {
        List<Vehicle> rentableVehicles = await (
            from v in DbContext.Vehicles
            join r in DbContext.Rentals on v.Id equals r.VehicleId
            into j
            from rental in j.DefaultIfEmpty()
            where rental == null ? v.LocationId == filters.PickUpLocationId :
                (rental.ReturnLocationId == filters.PickUpLocationId && rental.ReturnDate < filters.PickUpDate)
                || (rental.PickUpLocationId == filters.ReturnLocationId && rental.PickUpDate > filters.ReturnDate)
            select v
        )
        .Distinct()
        .ToListAsync();

        return rentableVehicles;
    }
}