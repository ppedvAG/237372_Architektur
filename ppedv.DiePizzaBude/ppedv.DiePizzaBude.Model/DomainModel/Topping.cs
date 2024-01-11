namespace ppedv.DiePizzaBude.Model.DomainModel
{
    public class Topping : Food
    {
        public virtual ICollection<Pizza> Pizzas { get; set; } = new HashSet<Pizza>();

    }

}
