namespace ppedv.DiePizzaBude.Model.DomainModel
{
    public class Order : Entity
    {
        public DateTime OrderDate { get; set; }
        public DateTime DeliverDate { get; set; }

        public OrderStatus  Status { get; set; }

        public virtual ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();

        public virtual Address? DeliveryAddress { get; set; }
        public virtual Address? BillingAddress { get; set; }

    }

    public enum OrderStatus
    {
        Unknown,
        Open,
        Accepted,
        Preparing,
        Delivering,
        Delivered,
        Canceled,
        Rejected,
        Lost
    }

}
