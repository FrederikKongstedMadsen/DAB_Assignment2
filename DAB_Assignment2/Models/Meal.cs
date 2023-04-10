using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAB_Assignment2.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }
        public virtual Canteen Canteen { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
