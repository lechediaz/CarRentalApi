
using CarRental.Application.Interfaces.Stores;
using CarRental.Domain.Dtos;

namespace CarRental.Application.Vehicles.ListRentableVehicles;

public class ListRentableVehiclesHandler : IRequestHandler<ListRentableVehiclesQuery, List<Vehicle>>
{
    private readonly IVehicleStore _vehicleStore;

    public ListRentableVehiclesHandler(IVehicleStore vehicleStore)
    {
        _vehicleStore = vehicleStore;
    }

    public async Task<List<Vehicle>> Handle(ListRentableVehiclesQuery request, CancellationToken cancellationToken)
    {
        var filters = new RentingFilters(
            request.PickUpDate,
            request.ReturnDate,
            request.PickUpLocationId,
            request.ReturnLocationId);

        List<Vehicle> rentableVehicles = await _vehicleStore.ListRentableVehiclesAsync(filters);

        return rentableVehicles;
    }
}