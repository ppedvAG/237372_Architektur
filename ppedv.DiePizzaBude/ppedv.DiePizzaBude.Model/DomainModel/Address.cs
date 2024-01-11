namespace ppedv.DiePizzaBude.Model.DomainModel
{
    public class Address : Entity
    {
        public string Name1 { get; set; } = string.Empty;
        public string Name2 { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;

        public virtual ICollection<Order> AsDeliveryAddress { get; set; } = new HashSet<Order>();
        public virtual ICollection<Order> AsBillingAddress { get; set; } = new HashSet<Order>();
    }

}
