using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public int CarBrandId { get; set; }
        public string? CarModelName { get; set; }
        public int CarCategoryId { get; set; }
        public string? Engine { get; set; }
        public DateTime ManufactureDate { get; set; }
        public double Price { get; set; }
        public Boolean IsDamaged { get; set; }
        public Boolean IsSold { get; set; }
        public DateTime SellDate { get; set; }
        public int SellerId { get; set; }
        public int LocationId { get; set; }
        public int PaymentId { get; set; }
        public CarBrand? carBrand { get; set; }
        public CarCategory? carCategory { get; set; }
        public Seller? seller { get; set; }
        public Location? location { get; set; }
        public Payment? payment { get; set; }

    }
}
