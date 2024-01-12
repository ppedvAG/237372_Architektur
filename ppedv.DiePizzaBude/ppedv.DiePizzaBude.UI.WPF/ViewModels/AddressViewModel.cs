using ppedv.DiePizzaBude.Model.Contracts;
using ppedv.DiePizzaBude.Model.DomainModel;
using System.ComponentModel;
using System.Windows.Input;

namespace ppedv.DiePizzaBude.UI.WPF.ViewModels
{
    public class AddressViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public List<Address> AddresseList { get; set; }

        private Address selectedAddress;

        public Address SelectedAddress
        {
            get => selectedAddress;
            set
            {
                selectedAddress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedAddress)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AddressUsageInfo)));
            }
        }

        public string AddressUsageInfo
        {
            get
            {
                if (SelectedAddress == null)
                    return string.Empty;

                return $"As Billing: {SelectedAddress.AsBillingAddress.Count} / As Delivery: {SelectedAddress.AsDeliveryAddress.Count}";
            }
        }

        public SaveCommand SaveCommand { get; }
        IRepository repo;

        public AddressViewModel()
        {
            string conString = "Server=(localdb)\\mssqllocaldb;Database=DiePizzaBude_dev;Trusted_Connection=true;";
            repo = new ppedv.DiePizzaBude.Data.EfCore.PizzaEfContextRepositoryAdapter(conString);
            //OrderServices orderService = new OrderServices(repo);

            AddresseList = new List<Address>(repo.GetAll<Address>());
            SaveCommand = new SaveCommand(repo);
        }
    }

    public class SaveCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        private IRepository repo;

        public SaveCommand(IRepository repo)
        {
            this.repo = repo;
        }

        public void Execute(object? parameter)
        {
            repo.SaveAll();
        }
    }
}
