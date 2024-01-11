using ppedv.DiePizzaBude.Logic.Core;
using ppedv.DiePizzaBude.Model.Contracts;
using Serilog;
using System.Reflection;

//Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("DE-de");
//Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("DE-de");

Console.WriteLine("*** Die Pizza Bude v1.0 ***");
InitLogger();
Log.Information("DevConsole started");

string conString = "Server=(localdb)\\mssqllocaldb;Database=DiePizzaBude_dev;Trusted_Connection=true;";


//Dependency Injection per Hand
//IRepository repo = new ppedv.DiePizzaBude.Data.EfCore.PizzaEfContextRepositoryAdapter(conString);
//OrderServices orderService = new OrderServices(repo);

//Dependency Injection per Reflection
var pathToLib = @"C:\Users\Fred\source\repos\237372_Architektur\ppedv.DiePizzaBude\ppedv.DiePizzaBude.Data.EfCore\bin\Debug\net8.0\ppedv.DiePizzaBude.Data.EfCore.dll";
var ass = Assembly.LoadFrom(pathToLib);
var repoType = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));
IRepository repo = Activator.CreateInstance(repoType,conString) as IRepository;
OrderServices orderService = new OrderServices(repo);


var ordersInProcess = orderService.GetAllOrdersInProcess().ToList();

Log.Information("{count} Orders in process found", ordersInProcess.Count());
foreach (var order in ordersInProcess)
{
    Console.WriteLine($"{order.OrderDate:g} To: {order.DeliveryAddress?.Name1}");
    foreach (var orderItem in order.Items)
    {
        Console.WriteLine($"{orderItem.Amount}x {orderItem.Food.Name} {orderItem.Food.Price:c}");
    }
    Log.Information("Order {orderDate} Sum: {sum}", order.OrderDate, orderService.CalcOrderPriceSum(order));
}


void InitLogger()
{
    Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()  //muss als generelles Minimun festgelegt werden
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Month, restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)
#if DEBUG
                .WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)
#else
                        .WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
#endif
                .Enrich.WithProperty("App", System.Diagnostics.Process.GetCurrentProcess().ProcessName)
                .Enrich.WithMachineName()
                .Enrich.WithEnvironmentUserName()
                .CreateLogger();
}