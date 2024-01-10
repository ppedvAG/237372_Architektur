namespace ppedv.DiePizzaBude.Model
{
    public class Topping : Food
    {
        public virtual ICollection<Pizza> Pizzas { get; set; } = new HashSet<Pizza>();

    }

}
