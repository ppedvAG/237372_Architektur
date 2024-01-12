using Moq;
using ppedv.DiePizzaBude.Logic.Core;
using ppedv.DiePizzaBude.Model.Contracts;
using ppedv.DiePizzaBude.Model.DomainModel;
using ppedv.DiePizzaBude.UI.WPF.ViewModels;

namespace ppedv.DiePizzaBude.UI.WPF.Tests
{
    public class AddressViewModelTests
    {
        [Fact]
        public void Set_SelectedAddress_should_show_order_sum()
        {
            var repoMock = new Mock<IRepository>();
            var osMock = new Mock<IOrderServices>();
            osMock.Setup(x => x.CalcOrderPriceSum(It.IsAny<Order>())).Returns(12.99m);

            var adr = new Address() { Name1 = "T2" };
            adr.AsDeliveryAddress.Add(new Order() { });

            var vm = new AddressViewModel(repoMock.Object, osMock.Object);
            vm.SelectedAddress = adr;

            Assert.StartsWith("sumAllOrders 12,99 €", vm.AddressUsageInfo);
        }
    }
}