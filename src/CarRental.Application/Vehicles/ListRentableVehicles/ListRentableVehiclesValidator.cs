using CarRental.Application.Common.Exceptions;
using CarRental.Application.Interfaces.Stores;

namespace CarRental.Application.Vehicles.ListRentableVehicles;

public class ListRentableVehiclesValidator : AbstractValidator<ListRentableVehiclesQuery>
{
    private readonly ILocationStore _locationStore;

    public ListRentableVehiclesValidator(ILocationStore locationStore)
    {
        _locationStore = locationStore;

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
    }

    private async Task<bool> LocationMustExists(ListRentableVehiclesQuery request, int locationId, CancellationToken cancellationToken)
    {
        bool exist = await _locationStore.ExistsByIdAsync(locationId, cancellationToken);

        if (!exist)
        {
            throw new NotFoundException("Location not found.");
        }

        return true;
    }
}