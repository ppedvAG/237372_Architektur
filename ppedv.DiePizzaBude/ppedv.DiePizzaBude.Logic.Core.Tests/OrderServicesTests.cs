using Moq;
using ppedv.DiePizzaBude.Model.Contracts;
using ppedv.DiePizzaBude.Model.DomainModel;

namespace ppedv.DiePizzaBude.Logic.Core.Tests
{
    public class OrderServicesTests
    {

        private readonly Mock<IRepository> mockRepository;
        private readonly OrderServices orderServices;

        public OrderServicesTests()
        {
            mockRepository = new Mock<IRepository>();
            orderServices = new OrderServices(mockRepository.Object);
        }

        [Fact]
        public void GetAllOrdersInProcess_ReturnsOnlyOpenAndDeliveringOrders_byChatGPT4()
        {
            // Arrange
            var orders = new List<Order>
            {
                new() { Status = OrderStatus.Open },
                new() { Status = OrderStatus.Unknown },
                new() { Status = OrderStatus.Delivering },
                new() { Status = OrderStatus.Lost }
            };

            mockRepository.Setup(repo => repo.GetAll<Order>()).Returns(orders.AsQueryable());

            // Act
            var result = orderServices.GetAllOrdersInProcess();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count()); // Expecting only 2 orders (Open and Delivering)
            Assert.Contains(result, order => order.Status == OrderStatus.Open);
            Assert.Contains(result, order => order.Status == OrderStatus.Delivering);
        }

        [Fact]
        public void GetAllOrdersInProcess_ReturnsCORRECT_Orders_CreatedByFastChat()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository>();
            var order = new Order { Status = OrderStatus.Open };
            repositoryMock.Setup(x => x.GetAll<Order>()).Returns(() => new[] { order }.AsQueryable());

            var services = new OrderServices(repositoryMock.Object);

            // Act
            var result = services.GetAllOrdersInProcess();

            // Assert
            Assert.Equal(1, result.Count());
            Assert.Equal(order, result.First());
        }
    }
}