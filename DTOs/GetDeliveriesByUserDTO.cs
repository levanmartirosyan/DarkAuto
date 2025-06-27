using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.DTOs
{
    public class GetDeliveriesByUserDTO
    {
        public int DeliveryId { get; set; }
        public string? DeliveryAddress { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool IsDelivered { get; set; }
        public string? CompanyName { get; set; }
        public string? TrackingNumber { get; set; }
        public decimal DeliveryCost { get; set; }
        public int CarId { get; set; }
        public string? CarBrandName { get; set; }
        public string? CarModelName { get; set; }
        public string? CarCategoryName { get; set; }
        public string? Engine { get; set; }
        public DateTime ManufactureDate { get; set; }
        public decimal Price { get; set; }
        public Boolean IsDamaged { get; set; }
        public Boolean IsSold { get; set; }
        public DateTime? SellDate { get; set; }
        public string? SellerName { get; set; }
        public string? LocationName { get; set; }
        public bool isPaid { get; set; }
    }
}
