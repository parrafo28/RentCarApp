using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentCarApp.Domain.Entities;
using RentCarApp.Frontend.Models;
using RentCarApp.Persistence;

namespace RentCarApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly DataContext _context;

        public StatusController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(string filter = "")
        {
            var list = await _context.Status
                .ToListAsync();

            if (!string.IsNullOrEmpty(filter))
            {
                list = list.Where(d => d.Name.ToLower().Contains(filter.ToLower()))
                           .ToList();
            }
            var listToReturn = new List<StatusDto>();
            foreach (var item in list)
            {
                listToReturn.Add(new StatusDto { Name = item.Name, Id= item.Id });
            }
            return Ok(listToReturn);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var status = await _context.Status.FindAsync(id);
            if (status == null)
            {
                return BadRequest("Not found");
            }
            return Ok(status);
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] StatusDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not found");
            }
            var status = new Status { Name = dto.Name };
            _context.Status.Add(status);
            await _context.SaveChangesAsync();
            return Ok(new { success = true, message = "Created successfully!" });
        }


    }
}
