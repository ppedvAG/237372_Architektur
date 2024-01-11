using Microsoft.EntityFrameworkCore;
using ppedv.DiePizzaBude.Model.DomainModel;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().ToTable(nameof(Food));
            modelBuilder.Entity<Pizza>().ToTable(nameof(Pizza));
            modelBuilder.Entity<Topping>().ToTable(nameof(Topping));

            modelBuilder.Entity<Order>().HasOne(x => x.BillingAddress).WithMany(x => x.AsBillingAddress);
            modelBuilder.Entity<Order>().HasOne(x => x.DeliveryAddress).WithMany(x => x.AsDeliveryAddress);
        }
    }
}
