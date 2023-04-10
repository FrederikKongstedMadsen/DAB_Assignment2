using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAB_Assignment2.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public int CPR { get; set; }
        public virtual Meal Meal { get; set; }
        public virtual ICollection<CanteenCustomer> CanteenCustomers { get; set; }


        public void AddRating(Canteen canteen, double rating)
        {
            if (rating > 0 && rating < 5)
            {
                var temp = new CanteenCustomer();
                temp.CanteenId = canteen.Id;
                temp.CustomerId = this.Id;
                temp.RatingDate = DateTime.Now;
                temp.RatingValue = rating;
                CanteenCustomers.Add(temp);
            }
        }
    }
}
