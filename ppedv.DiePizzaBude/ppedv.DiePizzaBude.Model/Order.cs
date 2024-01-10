namespace ppedv.DiePizzaBude.Model
{
    public class Order : Entity
    {
        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();

        public virtual Address? DeliveryAddress { get; set; }
        public virtual Address? BillingAddress { get; set; }

    }

}
