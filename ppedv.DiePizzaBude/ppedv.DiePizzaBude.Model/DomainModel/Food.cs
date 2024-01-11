namespace ppedv.DiePizzaBude.Model.DomainModel
{
    public abstract class Food : Entity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsOrderable { get; set; }
        public int KCal { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
    }

}
