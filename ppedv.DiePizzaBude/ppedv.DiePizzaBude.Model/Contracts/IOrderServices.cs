using ppedv.DiePizzaBude.Model.DomainModel;

namespace ppedv.DiePizzaBude.Logic.Core
{
    public interface IOrderServices
    {
        decimal CalcOrderKCalSum(Order order);
        decimal CalcOrderPriceSum(Order order);
        IEnumerable<Order> GetAllOrdersInProcess();
    }
}