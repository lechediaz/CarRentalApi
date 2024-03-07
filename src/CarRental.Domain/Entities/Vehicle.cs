using CarRental.Domain.Entities.Base;

namespace CarRental.Domain.Entities;

public class Vehicle : EntityBase
{
    public Vehicle(string brand, string model, string color, decimal fare, string description, Location? location = null)
    {
        Brand = brand;
        Model = model;
        Color = color;
        Fare = fare;
        Description = description;
        Location = location;
    }

    public string Brand { get; }
    public string Model { get; }
    public string Color { get; }
    public decimal Fare { get; }
    public string Description { get; }
    public Location? Location { get; }
}