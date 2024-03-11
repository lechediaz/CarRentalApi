using CarRental.Domain.Dtos;

namespace CarRental.Application.Vehicles.ListRentableVehicles;

public record ListRentableVehiclesQuery(DateTime PickUpDate, DateTime ReturnDate, int PickUpLocationId, int ReturnLocationId) : IRequest<List<Vehicle>>;