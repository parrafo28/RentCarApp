using Microsoft.AspNetCore.Mvc;
using RentCarApp.Domain.Entities;
using RentCarApp.Frontend.Models;

namespace RentCarApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleRepository _vehiclesRepository;

        public VehiclesController(VehicleRepository vehiclesRepository)
        {
            _vehiclesRepository = vehiclesRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(string filter = "")
        {
            return Ok(await _vehiclesRepository.GetAll(filter));
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var vehicles = await _vehiclesRepository.GetById(id);
            if (vehicles == null)
            {
                return BadRequest("Not found");
            }
            return Ok(vehicles);
        }



        [HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] VehicleDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not found");
            }
            var id = await _vehiclesRepository.Add(dto);
            return Ok(new { success = true, id = id, message = "Created successfully!" });
        }



        [HttpPut(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] VehicleDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not found");
            }
            var response = await _vehiclesRepository.Update(dto);
            if (!response)
            {
                return Ok(new { success = false, message = "We coulnd update" });
            }

            return Ok(new { success = true, message = "Updated successfully!" });
        }


    }
}
