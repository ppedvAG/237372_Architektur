using ppedv.DiePizzaBude.Model.Contracts;
using ppedv.DiePizzaBude.Model.DomainModel;

namespace ppedv.DiePizzaBude.Logic.Core
{
    public class OrderServices
    {
        private readonly IRepository repository;

        public OrderServices(IRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Order> GetAllOrdersInProcess()
        {
            return repository.GetAll<Order>()
                             .Where(x => x.Status >= OrderStatus.Open && 
                                         x.Status <= OrderStatus.Delivering);
        }

        public decimal CalcOrderPriceSum(Order order)
        {
            ArgumentNullException.ThrowIfNull(order);

            return order.Items.Sum(x => x.Food.Price * x.Amount);
        }

        public decimal CalcOrderKCalSum(Order order)
        {
            ArgumentNullException.ThrowIfNull(order);

            return order.Items.Sum(x => x.Food.KCal * x.Amount);
        }
    }
}
