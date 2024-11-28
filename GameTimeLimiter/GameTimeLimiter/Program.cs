namespace GameTimeLimiter
{
    internal static class Program
    {
        static void Main(string[] args)
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
           
        }
    }
}