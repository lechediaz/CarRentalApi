using CarRental.Application.Common.Interfaces;
using CarRental.Domain.Dtos;

namespace CarRental.Application.Interfaces.Stores;

public interface IVehicleStore : IStore<Vehicle>
{
    /// <summary>
    /// Allows to list rentable vehicles.
    /// </summary>
    /// <param name="filters">Filters to apply.</param>
    /// <returns>A list of rentable vehicles.</returns>
    Task<List<Vehicle>> ListRentableVehiclesAsync(RentingFilters filters);
}