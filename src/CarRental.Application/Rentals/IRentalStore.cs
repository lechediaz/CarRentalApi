using CarRental.Application.Common.Interfaces;

namespace CarRental.Application.Interfaces.Stores;

public interface IRentalStore : IStore<Rental>
{
    Task<Rental?> GetLastRentalAsync(int vehicleId, DateTime date, CancellationToken cancellationToken = default);
    Task<List<Rental>> GetListAsync(int vehicleId, DateTime date, CancellationToken cancellationToken = default);
}