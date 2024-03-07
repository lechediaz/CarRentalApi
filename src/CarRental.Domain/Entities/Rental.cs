using CarRental.Domain.Entities.Base;

namespace CarRental.Domain.Entities;

public class Rental : EntityBase
{
    public Rental(Vehicle vehicle, DateTime pickUpDate, DateTime returnDate, Location pickUpLocation, Location returnLocation)
    {
        Vehicle = vehicle;
        PickUpDate = pickUpDate;
        ReturnDate = returnDate;
        PickUpLocation = pickUpLocation;
        ReturnLocation = returnLocation;
    }

    public Vehicle Vehicle { get; }
    public DateTime PickUpDate { get; }
    public DateTime ReturnDate { get; }
    public Location PickUpLocation { get; }
    public Location ReturnLocation { get; }
    public decimal Total { get { return Vehicle.Fare; } }
}