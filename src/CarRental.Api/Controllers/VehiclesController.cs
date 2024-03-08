using CarRental.Application.Vehicles.Create;
using CarRental.Application.Vehicles.List;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers;

public class VehiclesController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Vehicle>>> Create()
    {
        return await Mediator.Send(new ListVehiclesQuery());
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateVehicleCommand command)
    {
        return await Mediator.Send(command);
    }
}