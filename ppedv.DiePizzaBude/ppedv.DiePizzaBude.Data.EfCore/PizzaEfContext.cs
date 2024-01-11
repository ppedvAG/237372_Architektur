using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        private readonly string conString;
        private readonly Microsoft.Extensions.Logging.ILoggerFactory? logFac;

        public PizzaEfContext(string conString, ILoggerFactory? logFac = null)
        {
            this.conString = conString;
            this.logFac = logFac;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conString).UseLazyLoadingProxies();

            if (logFac != null)
                optionsBuilder.EnableSensitiveDataLogging().UseLoggerFactory(logFac);
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
