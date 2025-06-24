using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public Boolean isPaid { get; set; }
        public double PaymentAmount { get; set; }
        public int DeliveryId { get; set; }
        public Delivery? Delivery { get; set; }
    }
}
