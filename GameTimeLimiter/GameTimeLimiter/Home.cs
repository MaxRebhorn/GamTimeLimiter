namespace GameTimeLimiter
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void game_time_Click(object sender, EventArgs e)
        {
            GameTime gameTimeForm = new GameTime();
            gameTimeForm.Show();
        }

        private void game_monitor_Click(object sender, EventArgs e)
        {
            GameMonitor gameMonitorForm = new GameMonitor();
            gameMonitorForm.Show();
        }

        private void options_Click(object sender, EventArgs e)
        {
            Options optionsForm = new Options();
            optionsForm.Show();
        }
      
        private void Home_Load(object sender, EventArgs e)
        {

        }
    }
}