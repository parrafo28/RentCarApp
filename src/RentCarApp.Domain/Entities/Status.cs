using Microsoft.VisualBasic;
using RentCarApp.Domain.Core;

namespace RentCarApp.Domain.Entities
{
    public class Status: BaseEntity
    { 
        public string Name { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
