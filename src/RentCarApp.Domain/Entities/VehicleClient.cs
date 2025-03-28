using RentCarApp.Domain.Core;

namespace RentCarApp.Domain.Entities
{
    public class VehicleClient: BaseEntity
    { 
        public int ClientId { get; set; }
        public int VehicleId { get; set; }
    }
}
