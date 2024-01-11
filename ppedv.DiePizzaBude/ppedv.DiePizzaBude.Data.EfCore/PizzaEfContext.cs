using Microsoft.EntityFrameworkCore;
using ppedv.DiePizzaBude.Model;

namespace ppedv.DiePizzaBude.Data.EfCore
{
    public class PizzaEfContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Topping> Toppings { get; set; }

        private string conString;

        public PizzaEfContext(string conString)
        {
            this.conString = conString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conString).UseLazyLoadingProxies(); 
        }
    }
}
