using CarRental.Application.Vehicles.Create;
using CarRental.Application.Vehicles.List;
using CarRental.Application.Vehicles.ListRentableVehicles;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;

public class VehiclesController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Vehicle>>> List()
    {
        return await Mediator.Send(new ListVehiclesQuery());
    }

    [HttpGet("RentableVehicles")]
    public async Task<ActionResult<List<Vehicle>>> ListRentableVehicles([FromQuery] ListRentableVehiclesQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateVehicleCommand command)
    {
        return await Mediator.Send(command);
    }
}