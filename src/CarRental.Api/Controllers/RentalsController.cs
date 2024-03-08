using CarRental.Application.Rentals.Create;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;

public class RentalsController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateRentalCommand command)
    {
        return await Mediator.Send(command);
    }
}