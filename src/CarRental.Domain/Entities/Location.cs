using CarRental.Domain.Entities.Base;

namespace CarRental.Domain.Entities;

public class Location : EntityBase
{
    public Location(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}