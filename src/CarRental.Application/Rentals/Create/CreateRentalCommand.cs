namespace CarRental.Application.Rentals.Create;

public record CreateRentalCommand(
    int VehicleId,
    DateTime PickUpDate,
    DateTime ReturnDate,
    int PickUpLocationId,
    int ReturnLocationId) : IRequest<int>;