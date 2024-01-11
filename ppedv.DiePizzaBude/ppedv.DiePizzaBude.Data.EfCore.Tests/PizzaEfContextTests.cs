using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using ppedv.DiePizzaBude.Model;
using System.Reflection;

namespace ppedv.DiePizzaBude.Data.EfCore.Tests
{
    public class PizzaEfContextTests
    {
        string conString = "Server=(localdb)\\mssqllocaldb;Database=DiePizzaBude_dev;Trusted_Connection=true;";

        [Fact]
        public void Can_create_DB()
        {
            using var con = new PizzaEfContext(conString);
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }

        [Fact]
        public void Can_add_Pizza()
        {
            var pizza = new Pizza() { Name = "P1", Price = 5.55m };
            using var con = new PizzaEfContext(conString);
            con.Database.EnsureCreated();

            con.Add(pizza);
            var rows = con.SaveChanges();

            rows.Should().Be(2);
        }

        [Fact]
        public void Can_read_Pizza()
        {
            var pizza = new Pizza() { Name = $"P1_{Guid.NewGuid()}", Price = 5.55m };
            using (var con = new PizzaEfContext(conString))
            {
                con.Database.EnsureCreated();
                con.Add(pizza);
                con.SaveChanges();
            }

            using (var con = new PizzaEfContext(conString))
            {
                var loaded = con.Pizzas.Find(pizza.Id);

                loaded.Should().NotBeNull();
                loaded?.Name.Should().Be(pizza.Name);
            }
        }

        [Fact]
        public void Can_update_Pizza()
        {
            var pizza = new Pizza() { Name = $"P1_{Guid.NewGuid()}", Price = 5.55m };
            var newName = $"P3_{Guid.NewGuid()}";
            using (var con = new PizzaEfContext(conString))
            {
                con.Database.EnsureCreated();
                con.Add(pizza);
                con.SaveChanges();
            }

            using (var con = new PizzaEfContext(conString))
            {
                var loaded = con.Pizzas.Find(pizza.Id);
                loaded.Name = newName;
                var rows = con.SaveChanges();
                rows.Should().Be(1);
            }

            using (var con = new PizzaEfContext(conString))
            {
                var loaded = con.Pizzas.Find(pizza.Id);
                loaded.Should().NotBeNull();
                loaded?.Name.Should().Be(newName);
            }
        }

        [Fact]
        public void Can_delete_Pizza()
        {
            var pizza = new Pizza() { Name = $"PD_{Guid.NewGuid()}", Price = 5.55m };
            using (var con = new PizzaEfContext(conString))
            {
                con.Database.EnsureCreated();
                con.Add(pizza);
                con.SaveChanges();
            }

            using (var con = new PizzaEfContext(conString))
            {
                var loaded = con.Pizzas.Find(pizza.Id);
                con.Remove(loaded);
                var rows = con.SaveChanges();
                rows.Should().Be(2);
            }

            using (var con = new PizzaEfContext(conString))
            {
                var loaded = con.Pizzas.Find(pizza.Id);
                loaded.Should().BeNull();
            }
        }

        [Fact]
        public void Can_create_and_read_Pizza_with_AutoFixture()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter(nameof(Entity.Id)));
            fix.Customizations.Add(new TypeRelay(typeof(Food), typeof(Pizza)));
            var p = fix.Create<Pizza>();

            using (var con = new PizzaEfContext(conString))
            {
                con.Database.EnsureCreated();
                con.Add(p);
                var rows = con.SaveChanges().Should().BeGreaterThan(6);
                //Console.WriteLine(rows);
            }
            using (var con = new PizzaEfContext(conString))
            {
                var loaded = con.Pizzas.Find(p.Id);

                loaded.Should().BeEquivalentTo(p, x => x.IgnoringCyclicReferences());
            }
        }

        internal class PropertyNameOmitter : ISpecimenBuilder
        {
            private readonly IEnumerable<string> names;

            internal PropertyNameOmitter(params string[] names)
            {
                this.names = names;
            }

            public object Create(object request, ISpecimenContext context)
            {
                var propInfo = request as PropertyInfo;
                if (propInfo != null && names.Contains(propInfo.Name))
                    return new OmitSpecimen();

                return new NoSpecimen();
            }
        }


    }
}