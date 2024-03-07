using MediatR;

namespace CarRental.Application.Locations.Create;

public class CreateLocationCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
}
