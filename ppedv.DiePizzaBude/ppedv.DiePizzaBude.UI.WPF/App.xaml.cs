using Microsoft.Extensions.DependencyInjection;
using ppedv.DiePizzaBude.Logic.Core;
using ppedv.DiePizzaBude.Model.Contracts;
using ppedv.DiePizzaBude.UI.WPF.ViewModels;
using System.Windows;

namespace ppedv.DiePizzaBude.UI.WPF
{
    public sealed partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();

            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            string conString = "Server=(localdb)\\mssqllocaldb;Database=DiePizzaBude_dev;Trusted_Connection=true;";

            services.AddScoped<IRepository>(x => new Data.EfCore.PizzaEfContextRepositoryAdapter(conString));
            services.AddSingleton<AddressViewModel>();
            services.AddSingleton<OrderServices>();

            return services.BuildServiceProvider();
        }
    }

}
