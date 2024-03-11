namespace CarRental.Domain.Dtos;

public record RentingFilters(DateTime PickUpDate, DateTime ReturnDate, int PickUpLocationId, int ReturnLocationId);