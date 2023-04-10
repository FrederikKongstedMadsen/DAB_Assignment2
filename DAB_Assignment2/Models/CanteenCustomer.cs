using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Assignment2.Models
{
    public class CanteenCustomer
    {
        public int CanteenId { get; set; }
        public int CustomerId { get; set; }
        public double RatingValue { get; set; }
        public DateTime RatingDate { get; set; }
        public virtual Canteen Canteen { get; set; }
        public virtual Customer Customer { get; set; }


    }
}
