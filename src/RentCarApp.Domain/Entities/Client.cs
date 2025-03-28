using RentCarApp.Domain.Core;

namespace RentCarApp.Domain.Entities
{
    public class Client: BaseEntity
    { 
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
