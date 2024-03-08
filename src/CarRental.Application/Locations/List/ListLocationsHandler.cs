using CarRental.Application.Interfaces.Stores;
using CarRental.Domain.Entities;

namespace CarRental.Application.Locations.List;

public class ListLocationsHandler : IRequestHandler<ListLocationsQuery, List<Location>>
{
    private readonly ILocationStore _locationStore;

    public ListLocationsHandler(ILocationStore locationStore)
    {
        _locationStore = locationStore;
    }

    public async Task<List<Location>> Handle(ListLocationsQuery request, CancellationToken cancellationToken)
    {
        return await _locationStore.GetListAsync(cancellationToken);
    }
}