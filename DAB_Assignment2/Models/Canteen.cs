using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Assignment2.Models
{
    public class Canteen
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Canteen> NearbyCanteens { get; set; }
        public virtual ICollection<CanteenCustomer> CanteenCustomers{ get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }

    }
}
