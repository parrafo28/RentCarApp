using Microsoft.VisualBasic;
using RentCarApp.Frontend.Models;

namespace RentCarApp.Domain.Entities
{
    public interface IStatusRepository
    {
        Task<List<StatusDto>> GetAll(string filter);
        Task<StatusDto> GetById(int id);
        Task<int> Add(StatusDto dto);
        Task<bool> Update(StatusDto dto);

    }
}
