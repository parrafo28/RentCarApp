using Microsoft.EntityFrameworkCore;
using RentCarApp.Frontend.Models;
using RentCarApp.Infrastructure.Core;
using RentCarApp.Persistence;

namespace RentCarApp.Domain.Entities
{
    public class Status2Repository : BaseRepository<Status>, IStatusRepository
    {
        public Status2Repository(DataContext context) : base(context) { }

        public async Task<List<StatusDto>> GetAll(string filter)
        {

            Console.WriteLine("sssdsdsd");
            var list = await Context.Status
                .ToListAsync();

            if (!string.IsNullOrEmpty(filter))
            {
                list = list.Where(d => d.Name.ToLower().Contains(filter.ToLower()))
                           .ToList();
            }
            var listToReturn = new List<StatusDto>();
            foreach (var item in list)
            {
                listToReturn.Add(new StatusDto { Name = item.Name, Id = item.Id });
            }

            return listToReturn;
        }

        public async Task<StatusDto> GetById(int id)
        {
            var entity = await GetEntityById(id);

            var dto = new StatusDto
            {
                Id = id,
                Name = entity.Name
            };
            return dto;
        }

        public async Task<int> Add(StatusDto dto)
        {
            var entity = new Status { Name = dto.Name };
            return await Add(entity);
        }

        public async Task<bool> Update(StatusDto dto)
        {
            var entity = await GetEntityById(dto.Id);
            if (entity == null)
            {
                return false;
            }
            entity.Name = dto.Name;

            await Update(entity);
            return true;
        }


    }
}
