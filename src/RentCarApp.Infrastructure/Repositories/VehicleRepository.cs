using Microsoft.EntityFrameworkCore;
using RentCarApp.Frontend.Models;
using RentCarApp.Infrastructure.Core;
using RentCarApp.Persistence;

namespace RentCarApp.Domain.Entities
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(DataContext context) : base(context) { }

        public async Task<List<VehicleDto>> GetAll(string filter)
        {
            var list = await Context.Vehicles
                .ToListAsync();

            if (!string.IsNullOrEmpty(filter))
            {
                list = list.Where(d => d.Model.ToLower().Contains(filter.ToLower()) ||
                 d.Brand.ToLower().Contains(filter.ToLower())
                ).ToList();
            }
            var listToReturn = new List<VehicleDto>();
            foreach (var item in list)
            {
                listToReturn.Add(new VehicleDto
                {
                    Brand = item.Brand,
                    Model = item.Model,
                    Price = item.Price,
                    StatusId = item.StatusId,
                    Year = item.Year,
                    Id = item.Id
                });
            }

            return listToReturn;
        }

        public async Task<VehicleDto> GetById(int id)
        {
            var entity = await GetEntityById(id);

            var dto = new VehicleDto
            {
                Id = id,
                Brand = entity.Brand,
                Model = entity.Model,
                Price = entity.Price,
                StatusId = entity.StatusId,
                Year = entity.Year
            };
            return dto;
        }

        public async Task<int> Add(VehicleDto dto)
        {
            var entity = new Vehicle
            {
                Id = dto.Id,
                Brand = dto.Brand,
                Model = dto.Model,
                Price = dto.Price,
                StatusId = dto.StatusId,
                Year = dto.Year
            };

            return await Add(entity);
        }

        public async Task<bool> Update(VehicleDto dto)
        {
            var entity = await GetEntityById(dto.Id);
            if (entity == null)
            {
                return false;
            }

            entity.Brand = dto.Brand;
            entity.Model = dto.Model;
            entity.Price = dto.Price;
            entity.StatusId = dto.StatusId;
            entity.Year = dto.Year;
            await Update(entity);

            return true;
        }


    }
}
