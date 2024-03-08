using CarRental.Domain.Entities.Base;

namespace CarRental.Domain.Entities;

public class Vehicle : EntityBase
{
    public Vehicle(string brand, string model, string color, decimal fare, string description, int locationId)
    {
        Brand = brand;
        Model = model;
        Color = color;
        Fare = fare;
        Description = description;
        LocationId = locationId;
    }

    public string Brand { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public decimal Fare { get; set; }
    public string Description { get; set; }
    public int LocationId { get; set; }
    public Location Location { get; set; }
}