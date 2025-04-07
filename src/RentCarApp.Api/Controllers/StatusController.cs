using Microsoft.AspNetCore.Mvc;
using RentCarApp.Domain.Entities;
using RentCarApp.Frontend.Models;
using RentCarApp.Infrastructure.Core;

namespace RentCarApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StatusController(IStatusRepository statusRepository, IUnitOfWork unitOfWork)
        {
            _statusRepository = statusRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll(string filter = "")
        {
            return Ok(await _statusRepository.GetAll(filter));
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var status = await _statusRepository.GetById(id);
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
            int id = 0;
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                id = await _statusRepository.Add(dto);
                await _unitOfWork.CompleteAsync();
                await _unitOfWork.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }

            return Ok(new { success = true, id = id, message = "Created successfully!" });
        }



        [HttpPut(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] StatusDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not found");
            }
            var response = await _statusRepository.Update(dto);
            if (!response)
            {
                return Ok(new { success = false, message = "We coulnd update" });
            }

            return Ok(new { success = true, message = "Updated successfully!" });
        }


    }
}
