using CarRental.Application.Interfaces.Stores;

namespace CarRental.Infraestructure.Persistence.Stores;

public class RentalStore : StoreBase<Rental>, IRentalStore
{
    public RentalStore(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Rental?> GetLastRentalAsync(int vehicleId, DateTime date, CancellationToken cancellationToken = default)
    {
        return await DbContext.Rentals
            .Where(r => r.VehicleId == vehicleId && r.ReturnDate <= date)
            .OrderByDescending(r => r.ReturnDate)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<Rental>> GetListAsync(int vehicleId, DateTime date, CancellationToken cancellationToken = default)
    {
        return await DbContext.Rentals
            .Where(r => r.VehicleId == vehicleId && r.PickUpDate >= date)
            .OrderBy(r => r.PickUpDate)
            .ToListAsync(cancellationToken);
    }
}