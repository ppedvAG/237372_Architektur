namespace HalloSingelton
{
    internal class Logger
    {
        private static Logger instance;
        private static object sync = new object();

        public static Logger Instance
        {
            get
            {
                lock (sync)
                {
                    if (instance == null)
                        instance = new Logger();
                }

                return instance;
            }
        }

        private Logger()
        {
            Info("Neue Logger instanz");
        }

        public void Info(string msg)
        {
            Console.WriteLine($"{DateTime.Now:g} [INFO]  {msg}");
        }

        public void Error(string msg)
        {
            Console.WriteLine($"{DateTime.Now:g} [ERROR] {msg}");
        }
    }
}
