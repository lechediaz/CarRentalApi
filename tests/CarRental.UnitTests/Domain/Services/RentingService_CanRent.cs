using CarRental.Domain.Dtos;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Domain.Services;

namespace CarRental.UnitTests.Domain.Services;

public class RentingService_CanRent
{
    private readonly IRentingService _rentingService;
    private readonly Vehicle _vehicleInLocation1 = new(
        string.Empty,
        string.Empty,
        string.Empty,
        (decimal)120.2,
        string.Empty,
        1)
    {
        Id = 1
    };

    private readonly List<Rental> _rentsWithSameLocations = new()
    {
        new(1, new DateTime(2024, 3, 6, 10, 20, 0), new DateTime(2024, 3, 8, 14, 15, 0), 1 , 1),
        new(1, new DateTime(2024, 3, 15, 5, 45, 0), new DateTime(2024, 3, 18, 5, 45, 0), 1 , 1),
    };

    private readonly List<Rental> _rentsWithDiferentLocations = new()
    {
        new(1, new DateTime(2024, 3, 6, 10, 20, 0), new DateTime(2024, 3, 8, 14, 15, 0), 1 , 2),
        new(1, new DateTime(2024, 3, 15, 5, 45, 0), new DateTime(2024, 3, 18, 5, 45, 0), 2 , 2),
    };

    public RentingService_CanRent()
    {
        _rentingService = new RentingService();
    }

    [Fact]
    public void CanRent_When_ThereAreAnyRentals()
    {
        var newRental = new Rental(
            1,
            new DateTime(2024, 3, 6, 10, 20, 0),
            new DateTime(2024, 3, 8, 14, 15, 0),
            1,
            1);

        var rentingDto = new RentingDto(1, newRental, new());

        bool canRent = _rentingService.CanRent(rentingDto);

        Assert.True(canRent);
    }

    [Fact]
    public void CanRent_When_BetweenRentsWithSameLocation()
    {
        var newRental = new Rental(
            1,
            new DateTime(2024, 3, 10, 9, 0, 0),
            new DateTime(2024, 3, 10, 20, 30, 0),
            1,
            1);

        var rentingDto = new RentingDto(1, newRental, _rentsWithSameLocations);

        bool canRent = _rentingService.CanRent(rentingDto);

        Assert.True(canRent);
    }

    [Fact]
    public void CannotRent_When_BetweenRentsButRentalHasDifferentPickUpLocation()
    {
        var newRental = new Rental(
            1,
            new DateTime(2024, 3, 6, 10, 20, 0),
            new DateTime(2024, 3, 8, 14, 15, 0),
            2,
            1);

        var rentingDto = new RentingDto(1, newRental, _rentsWithSameLocations);

        bool canRent = _rentingService.CanRent(rentingDto);

        Assert.False(canRent);
    }
}