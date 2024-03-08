using CarRental.Application.Interfaces.Stores;
using CarRental.Domain.Entities;

namespace CarRental.Application.Locations.Create;

public class CreateLocationHandler : IRequestHandler<CreateLocationCommand, int>
{
    private readonly ILocationStore locationStore;

    public CreateLocationHandler(ILocationStore locationStore)
    {
        this.locationStore = locationStore;
    }

    public async Task<int> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var newLocation = new Location(request.Name);
        await locationStore.AddAsync(newLocation, cancellationToken);
        return newLocation.Id;
    }
}