using Microsoft.Extensions.DependencyInjection;
using ppedv.DiePizzaBude.UI.WPF.ViewModels;
using System.Windows.Controls;


namespace ppedv.DiePizzaBude.UI.WPF.Views
{
    /// <summary>
    /// Interaction logic for AddressView.xaml
    /// </summary>
    public partial class AddressView : UserControl
    {
        public AddressView()
        {
            InitializeComponent();

            DataContext = App.Current.Services.GetService<AddressViewModel>();
        }
    }
}
