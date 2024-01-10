namespace ppedv.DiePizzaBude.Model
{
    public class OrderItem : Entity
    {
        public int Amount { get; set; }
        public virtual Order? Order { get; set; }
        public virtual required Food Food { get; set; }
    }

}
