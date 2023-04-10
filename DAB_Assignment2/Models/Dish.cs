using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Assignment2.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Canteen> Canteens { get; set; }
        public virtual Meal Meal { get; set; }

    }
}
