using CarRental.Domain.Entities;

namespace CarRental.Domain.Dtos;

public record RentingDto(int ActualVehicleLocationId, Rental NewRental, List<Rental> Rentals);