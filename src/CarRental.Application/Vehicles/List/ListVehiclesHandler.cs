
using CarRental.Application.Interfaces.Stores;

namespace CarRental.Application.Vehicles.List;

public class ListVehiclesHandler : IRequestHandler<ListVehiclesQuery, List<Vehicle>>
{
    private readonly IVehicleStore _vehicleStore;

    public ListVehiclesHandler(IVehicleStore vehicleStore)
    {
        _vehicleStore = vehicleStore;
    }

    public async Task<List<Vehicle>> Handle(ListVehiclesQuery request, CancellationToken cancellationToken)
    {
        return await _vehicleStore.GetListAsync(cancellationToken);
    }
}