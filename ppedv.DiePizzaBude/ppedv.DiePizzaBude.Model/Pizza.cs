namespace ppedv.DiePizzaBude.Model
{
    public class Pizza : Food
    {
        public PizzaSize Size { get; set; } = PizzaSize.Medium;
        public virtual ICollection<Topping> Toppings { get; set; } = new HashSet<Topping>();
    }

}
