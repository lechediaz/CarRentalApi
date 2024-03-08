using CarRental.Application.Common.Exceptions;
using CarRental.Application.Interfaces.Stores;
using CarRental.Domain.Interfaces;

namespace CarRental.Application.Rentals.Create;

public class CreateRentalValidator : AbstractValidator<CreateRentalCommand>
{
    private readonly ILocationStore _locationStore;
    private readonly IVehicleStore _vehicleStore;

    public CreateRentalValidator(ILocationStore locationStore, IVehicleStore vehicleStore)
    {
        _locationStore = locationStore;
        _vehicleStore = vehicleStore;

        DateTime now = DateTime.UtcNow;

        RuleFor(p => p.PickUpDate).GreaterThan(now)
            .LessThan(p => p.ReturnDate);
        RuleFor(p => p.ReturnDate).GreaterThan(now)
            .GreaterThan(p => p.PickUpDate);
        RuleFor(p => p.PickUpLocationId).Cascade(CascadeMode.Stop)
            .GreaterThan(0)
            .MustAsync(LocationMustExists);
        RuleFor(p => p.ReturnLocationId).Cascade(CascadeMode.Stop)
            .GreaterThan(0)
            .MustAsync(LocationMustExists);
        RuleFor(p => p.VehicleId).Cascade(CascadeMode.Stop)
            .GreaterThan(0)
            .MustAsync(VehicleMustExists);
    }

    private async Task<bool> LocationMustExists(CreateRentalCommand request, int locationId, CancellationToken cancellationToken)
    {
        bool exist = await _locationStore.ExistsByIdAsync(locationId, cancellationToken);

        if (!exist)
        {
            throw new NotFoundException("Location not found.");
        }

        return true;
    }

    private async Task<bool> VehicleMustExists(CreateRentalCommand request, int vehicleId, CancellationToken cancellationToken)
    {
        bool exist = await _vehicleStore.ExistsByIdAsync(vehicleId, cancellationToken);

        if (!exist)
        {
            throw new NotFoundException("Vehicle not found.");
        }

        return true;
    }
}