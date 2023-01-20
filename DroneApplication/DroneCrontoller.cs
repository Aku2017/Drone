using DroneApplication.Application.Commands.Create;
using DroneApplication.Application.Queries;
using DroneApplication.Application.Responses;
using DroneApplication.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DroneApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DroneController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DroneController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register Drone")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DroneResponse>> CreateDrone([FromBody] CreateDroneCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("LoadDroneWithMedicationItems")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MedicationResponse>> CreateMedication([FromBody]CreateMedicationCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("CheckMedicationItemsforDrone")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<MedicationResponse>> GetMedicationItemsforDrone(string droneSerialNumber)
        {
            return await _mediator.Send(new GetAllMedicationQuery(droneSerialNumber));
        }

        [HttpGet("CheckDroneAvailableforLoading")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Drone>> CheckAvailableDrones()
        {
            return await _mediator.Send(new GetAllDroneQuery());
        }


        [HttpGet("CheckSpecificBatteryforDrone")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<DroneBatteryResponse> CheckDroneBatteryLevel(string name)
        {
            return await _mediator.Send(new GetDroneBatteryQuery(name));
        }

        [HttpGet("CheckDroneBatteriesPeriodically")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<DroneBatteryResponse>>PeriodicCheckofDroneBattery()
        {
            return await _mediator.Send(new GetAllDroneBatteryQuery());
        }



    }

}
