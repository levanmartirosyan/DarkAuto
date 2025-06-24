using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkAuto.Models
{
    public class Bid
    {
        public int BidId { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public double BidAmount { get; set; }
        public DateTime BidDate { get; set; }
        public User? User { get; set; }
        public Car? Car { get; set; }
    }
}
