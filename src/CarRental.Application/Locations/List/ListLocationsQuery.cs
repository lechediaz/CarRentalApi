using CarRental.Domain.Entities;

namespace CarRental.Application.Locations.List;

public record ListLocationsQuery : IRequest<List<Location>>;