namespace CarRental.Application.Locations.Create;

public record CreateLocationCommand(string Name) : IRequest<int>;
