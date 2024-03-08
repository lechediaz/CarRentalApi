
using CarRental.Application.Interfaces.Stores;
using CarRental.Domain.Entities;

namespace CarRental.Application.Vehicles.Create;

public class CreateVehicleHandler : IRequestHandler<CreateVehicleCommand, int>
{
    private readonly IVehicleStore _vehicleStore;

    public CreateVehicleHandler(IVehicleStore vehicleStore)
    {
        _vehicleStore = vehicleStore;
    }

    public async Task<int> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var newVehicle = new Vehicle(
            request.Brand,
            request.Model,
            request.Color,
            request.Fare,
            request.Description,
            request.LocationId);

        await _vehicleStore.AddAsync(newVehicle, cancellationToken);

        return newVehicle.Id;
    }
}