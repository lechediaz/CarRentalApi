
using CarRental.Application.Interfaces.Stores;
using CarRental.Domain.Dtos;
using CarRental.Domain.Interfaces;

namespace CarRental.Application.Rentals.Create;

public class CreateRentalHandler : IRequestHandler<CreateRentalCommand, int>
{
    private readonly IRentalStore _rentalStore;
    private readonly IRentingService _rentingService;
    private readonly IVehicleStore _vehicleStore;

    public CreateRentalHandler(IRentalStore rentalStore, IRentingService rentingService, IVehicleStore vehicleStore)
    {
        _rentalStore = rentalStore;
        _rentingService = rentingService;
        _vehicleStore = vehicleStore;
    }

    public async Task<int> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
    {
        int vehicleId = request.VehicleId;
        DateTime pickUpDate = request.PickUpDate;
        Vehicle vehicle = (await _vehicleStore.GetByIdAsync(vehicleId, cancellationToken))!;
        Rental? lastRental = await _rentalStore.GetLastRentalAsync(vehicleId, pickUpDate, cancellationToken);
        List<Rental> rentals = await _rentalStore.GetListAsync(vehicleId, lastRental?.PickUpDate ?? pickUpDate, cancellationToken);

        var newRental = new Rental(
            request.VehicleId,
            request.PickUpDate,
            request.ReturnDate,
            request.PickUpLocationId,
            request.ReturnLocationId);

        var rentingDto = new RentingDto(vehicle.LocationId, newRental, rentals);

        if (!_rentingService.CanRent(rentingDto))
        {
            throw new ValidationException("Cannot rent this car, please try another date range or locations.");
        }

        await _rentalStore.AddAsync(newRental, cancellationToken);

        return newRental.Id;
    }
}