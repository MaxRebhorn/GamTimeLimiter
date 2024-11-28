namespace GameTimeLimiter
{
    internal static class Program
    {
        private static Mutex mutex = null;

        static void Main(string[] args)
        {
            // Check if the application is already running
            const string mutexName = "RUNNINGME";
            bool createdNew;

            mutex = new Mutex(true, mutexName, out createdNew);

            if (createdNew)
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();

                if (args != null && args.Length > 0 && args[0] == "game_time_over")
                {
                    Application.Run(new GameTimeOver());
                }
                else
                {
                    Application.Run(new Login());
                }
                
                mutex.ReleaseMutex();
            }
            else
            {
                // An instance is already running, show a message or something
                MessageBox.Show("An instance of the application is already running.");
            }
        }
    }
}