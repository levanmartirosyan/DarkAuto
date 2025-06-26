using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public int? CarId { get; set; }
        public string? DeliveryAddress { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Boolean IsDelivered { get; set; }
        public int DeliveryCompanyId { get; set; }
        public string? TrackingNumber { get; set; }
        public double DeliveryCost { get; set; }
        public int UserId { get; set; }
        public int? PaymentId { get; set; }
        public Car? Car { get; set; }
        public User? User { get; set; }
        public DeliveryCompany? DeliveryCompany { get; set; }
        public Payment? Payment { get; set; }
    }
}
