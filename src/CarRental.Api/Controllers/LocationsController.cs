using CarRental.Application.Locations.Create;
using CarRental.Application.Locations.List;
using CarRental.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;

public class LocationsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Location>>> List()
    {
        return await Mediator.Send(new ListLocationsQuery());
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateLocationCommand command)
    {
        return await Mediator.Send(command);
    }
}