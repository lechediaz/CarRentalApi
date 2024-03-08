namespace CarRental.Application.Vehicles.Create;

public record CreateVehicleCommand(
    string Brand,
    string Model,
    string Color,
    decimal Fare,
    string Description,
    int LocationId) : IRequest<int>;