using RentCarApp.Frontend.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RentCarApp.Domain.Entities
{
    public interface IVehicleRepository
    {
        Task<int> Add(VehicleDto dto);
        Task<List<VehicleDto>> GetAll(string filter);
        Task<VehicleDto> GetById(int id);
        Task<bool> Update(VehicleDto dto);
    }
}
