
using HalloSingelton;

Console.WriteLine("Hello Singelton");
//var log = new Logger();

for (int i = 0; i < 10; i++)
{
    Task.Run(() => { Logger.Instance.Info($"Task {i}"); });
}

Logger.Instance.Info("Test 1");
Logger.Instance.Info("Test 2");
Logger.Instance.Info("Test 3");

Logger.Instance.Error("Panik");