using CarRental.Application.Common.Exceptions;
using CarRental.Application.Interfaces.Stores;

namespace CarRental.Application.Vehicles.Create;

public class CreateVehicleValidator : AbstractValidator<CreateVehicleCommand>
{
    private readonly ILocationStore _locationStore;

    public CreateVehicleValidator(ILocationStore locationStore)
    {
        _locationStore = locationStore;

        RuleFor(p => p.LocationId).Cascade(CascadeMode.Stop)
        .GreaterThan(0)
        .MustAsync(LocationMustExists)
        .DependentRules(() =>
        {
            RuleFor(p => p.Brand).NotEmpty().MaximumLength(30);
            RuleFor(p => p.Color).NotEmpty().MaximumLength(30);
            RuleFor(p => p.Description).NotEmpty().MaximumLength(120);
            RuleFor(p => p.Fare).GreaterThan(0);
            RuleFor(p => p.LocationId);
            RuleFor(p => p.Model).NotEmpty().MaximumLength(30);
        });
    }

    private async Task<bool> LocationMustExists(CreateVehicleCommand request, int locationId, CancellationToken cancellationToken)
    {
        bool exist = await _locationStore.ExistsByIdAsync(locationId, cancellationToken);

        if (!exist)
        {
            throw new NotFoundException("Location not found.");
        }

        return true;
    }
}