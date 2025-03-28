using Microsoft.VisualBasic;

namespace RentCarApp.Domain.Entities
{
    public class StatusModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<VehicleModel> Vehicles { get; set; }
    }
}
