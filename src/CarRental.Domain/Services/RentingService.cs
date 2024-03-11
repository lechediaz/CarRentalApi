using CarRental.Domain.Dtos;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;

namespace CarRental.Domain.Services;

public class RentingService : IRentingService
{
    public bool CanRent(RentingDto rentingDto)
    {
        Rental newRental = rentingDto.NewRental;
        IOrderedEnumerable<Rental> lastRentals = rentingDto.Rentals
            .Where(r => r.VehicleId == newRental.VehicleId && r.ReturnDate < newRental.PickUpDate)
            .OrderByDescending(r => r.ReturnDate);
        IOrderedEnumerable<Rental> nextRentals = rentingDto.Rentals
            .Where(r => r.VehicleId == newRental.VehicleId && r.PickUpDate > newRental.ReturnDate)
            .OrderBy(r => r.PickUpDate);
        Rental? lastRental = lastRentals.FirstOrDefault();
        Rental? nextRental = nextRentals.FirstOrDefault();

        bool hasRentals = rentingDto.Rentals.Any();
        bool hasLastRentals = lastRentals.Any();
        bool hasNextRentals = nextRentals.Any();
        bool aRentalExistsInSameDateRange = rentingDto.Rentals
            .Where(r => r.VehicleId == newRental.VehicleId && r.PickUpDate >= newRental.PickUpDate
                && r.ReturnDate <= newRental.ReturnDate)
            .Any();
        bool isInLocation = newRental.PickUpLocationId == rentingDto.ActualVehicleLocationId;
        bool wasReturnedInPickupLocation = lastRental?.ReturnLocationId == newRental.PickUpLocationId;
        bool willBePickedUpInReturnLocation = nextRental?.PickUpLocationId == newRental.ReturnLocationId;

        if (!hasRentals && isInLocation) return true;
        if (hasLastRentals && hasNextRentals && !aRentalExistsInSameDateRange
            && wasReturnedInPickupLocation && willBePickedUpInReturnLocation) return true;
        if (hasLastRentals && !hasNextRentals && wasReturnedInPickupLocation) return true;
        if (!hasLastRentals && hasNextRentals && willBePickedUpInReturnLocation) return true;

        return false;
    }
}