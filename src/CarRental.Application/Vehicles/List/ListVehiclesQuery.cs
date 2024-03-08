namespace CarRental.Application.Vehicles.List;

public record ListVehiclesQuery() : IRequest<List<Vehicle>>;