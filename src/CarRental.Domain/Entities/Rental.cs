using CarRental.Domain.Entities.Base;

namespace CarRental.Domain.Entities;

public class Rental : EntityBase
{
    public Rental(int vehicleId, DateTime pickUpDate, DateTime returnDate, int pickUpLocationId, int returnLocationId)
    {
        VehicleId = vehicleId;
        PickUpDate = pickUpDate;
        ReturnDate = returnDate;
        PickUpLocationId = pickUpLocationId;
        ReturnLocationId = returnLocationId;
    }

    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public DateTime PickUpDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public int PickUpLocationId { get; set; }
    public Location PickUpLocation { get; set; }
    public int ReturnLocationId { get; set; }
    public Location ReturnLocation { get; set; }
    public decimal Total { get { return Vehicle.Fare; } }
}