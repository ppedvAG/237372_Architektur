using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ppedv.DiePizzaBude.Logic.Core;
using ppedv.DiePizzaBude.Model.Contracts;
using ppedv.DiePizzaBude.Model.DomainModel;
using System.Collections.ObjectModel;

namespace ppedv.DiePizzaBude.UI.WPF.ViewModels
{
    public partial class AddressViewModel : ObservableObject
    {
        public ObservableCollection<Address> AddresseList { get; set; }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(AddressUsageInfo))]
        private Address selectedAddress;

        public string AddressUsageInfo
        {
            get
            {
                if (SelectedAddress == null)
                    return string.Empty;

                var sumAllOrders = SelectedAddress.AsBillingAddress.Union(SelectedAddress.AsDeliveryAddress).Sum(x => orderServices.CalcOrderPriceSum(x));
                return $"sumAllOrders {sumAllOrders:c} / As Billing: {SelectedAddress.AsBillingAddress.Count} / As Delivery: {SelectedAddress.AsDeliveryAddress.Count}";
            }
        }

        public RelayCommand SaveCommand { get; }

        [RelayCommand()]
        public void AddNewAddress()
        {
            var newAdr = new Address() { Name1 = "Fred" };
            repo.Add(newAdr);
            AddresseList.Add(newAdr);
            SelectedAddress = newAdr;
        }

        IRepository repo;
        private readonly IOrderServices orderServices;

        public AddressViewModel(IRepository repo, IOrderServices orderServices)
        {
            this.repo = repo;
            this.orderServices = orderServices;
            AddresseList = new ObservableCollection<Address>(repo.GetAll<Address>());

            SaveCommand = new RelayCommand(() => repo.SaveAll());
        }
    }
}
