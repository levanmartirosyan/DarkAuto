using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.DTOs
{
    public class GetAllCarsDTO
    {
        public int CarId { get; set; }
        public int CarBrandId { get; set; }
        public string? CarBrandName { get; set; }
        public string? CarModelName { get; set; }
        public int CarCategoryId { get; set; }
        public string? CarCategoryName { get; set; }
        public string? Engine { get; set; }
        public DateTime ManufactureDate { get; set; }
        public decimal Price { get; set; }
        public Boolean IsDamaged { get; set; }
        public Boolean IsSold { get; set; }
        public DateTime? SellDate { get; set; }
        public int SellerId { get; set; }
        public string? SellerName { get; set; }
        public int LocationId { get; set; }
        public string? LocationName { get; set; }
    }
}
