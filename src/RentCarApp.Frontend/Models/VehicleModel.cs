﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RentCarApp.Frontend.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "La cantidad maxima de caracteres es 50")]
        [DisplayName("Marca")]
        public string Brand { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }
        public int StatusId { get; set; }
        public SelectList? Status { get;  set; }
    }
}
