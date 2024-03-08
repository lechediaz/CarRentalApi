using CarRental.Domain.Dtos;

namespace CarRental.Domain.Interfaces;

public interface IRentingService
{
    /// <summary>
    /// Determines if a new rental can be done.
    /// </summary>
    /// <param name="rentingDto">Information about the rent.</param>
    /// <returns>True if can rent, otherwise false.</returns>
    bool CanRent(RentingDto rentingDto);
}