
using DAB_Assignment2.Data;
using DAB_Assignment2.Models;
using Microsoft.EntityFrameworkCore;

using (var db = new DabDbContext())
{
    ClearData(db);
    SeedDb(db);

    var dishes = db.Canteens.Include(c => c.Dishes).ToList();
    dishes.ForEach(Console.WriteLine);


}


void ClearData(DabDbContext db)
{
    var customers = db.Customers.ToList();
    var canteens = db.Canteens.ToList();
    var dishes = db.Dishes.ToList();
    var meals = db.Meals.ToList();
    var canteenCustomers = db.CanteenCustomer.ToList();

    db.RemoveRange(customers);
    db.RemoveRange(canteens);
    db.RemoveRange(dishes);
    db.RemoveRange(meals);
    db.RemoveRange(canteenCustomers);
    db.SaveChanges();
}

void SeedDb(DabDbContext db)
{
    var customer1 = new Customer { CPR = 1101981111 };
    var customer2 = new Customer { CPR = 0101981221 };
    var customer3 = new Customer { CPR = 1009668888 };
    var customer4 = new Customer { CPR = 0202029999 };

    var dish1 = new Dish { Name = "Green soup", Type = "Warm dish" };
    var dish2 = new Dish { Name = "Grilled sandwich", Type = "Street food" };
    var dish3 = new Dish { Name = "Pizza", Type = "JIT" };

    var canteen1 = new Canteen { Name = "Kongelig bibliotek" };
    var canteen2 = new Canteen { Name = "Matematisk kantine" };
    var canteen3 = new Canteen { Name = "FoodRUs" };

    var meal1 = new Meal();
    var meal2 = new Meal();
    var meal3 = new Meal();

    meal1.Dishes.Add(dish1);
    meal1.Dishes.Add(dish2);

    meal2.Dishes.Add(dish1);
    meal2.Dishes.Add(dish3);

    meal3.Dishes.Add(dish2);
    meal3.Dishes.Add(dish3);

    customer1.Meal = meal1;
    customer2.Meal = meal2;
    customer3.Meal = meal3;

    canteen1.Dishes.Add(dish1);
    canteen1.Dishes.Add(dish2);
    canteen1.Meals.Add(meal1);
    canteen1.NearbyCanteens.Add(canteen2);
    canteen1.NearbyCanteens.Add(canteen3);
    

    canteen2.Dishes.Add(dish1);
    canteen2.Dishes.Add(dish3);
    canteen2.Meals.Add(meal2);
    canteen2.NearbyCanteens.Add(canteen1);

    canteen3.Dishes.Add(dish2);
    canteen3.Dishes.Add(dish3);
    canteen3.Meals.Add(meal3);
    canteen3.NearbyCanteens.Add(canteen1);

    customer1.AddRating(canteen1, 4.6);
    customer2.AddRating(canteen2, 1.2);
    customer3.AddRating(canteen3, 2.4);

    db.SaveChanges();
}