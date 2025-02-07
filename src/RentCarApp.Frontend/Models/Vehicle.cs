using RentCarApp.Frontend.Controllers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RentCarApp.Frontend.Models
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "La cantidad maxima de caracteres es 50")]
        [DisplayName("Marca")]
        public string Brand { get; set; }
        [StringLength(50)]
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }

        void Eden()
        {
            var controller = new HomeController();
            controller.Index();
        
        }
    }
}
