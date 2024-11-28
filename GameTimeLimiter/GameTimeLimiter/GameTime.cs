using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Configuration;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace GameTimeLimiter
{
    
    public partial class GameTime : Form
    {
        private UserSettingsLimiter userSettings;
        private List<GameData> gameSettings; // Change this to list

        public GameTime()
        {
            InitializeComponent();

            var userSettingsPath = ConfigurationManager.AppSettings["UserDataPath"];
            string userJsonString = System.IO.File.ReadAllText(userSettingsPath);
            userSettings = JsonSerializer.Deserialize<UserSettingsLimiter>(userJsonString);

            var gameSettingsPath = ConfigurationManager.AppSettings["GameDataPath"];
            string gameJsonString = System.IO.File.ReadAllText(gameSettingsPath);
            gameSettings = JsonSerializer.Deserialize<List<GameData>>(gameJsonString); // Now it's correct
            
            setup_labels();
        }

        private void GameTimecs_Load(object sender, EventArgs e)
        {

        }

        private void setup_labels()
        {
            PlayTime.Text = CalculateTodayPlayedTime().ToString();
            bonubonus_time.Text =  userSettings.User.DailyTimeExtra.ToString();
            
        }

        private int CalculateTodayPlayedTime()
        {
            int totalPlayedToday = 0;  

            foreach (var game in gameSettings)
            {
                totalPlayedToday += game.TimePlayed.today;
            }
    
            return totalPlayedToday;
        }

    }

    public class Admin
    {
        public string Password { get; set; }
        public int DailyTimeLimit { get; set; }
    }
    // Rename the classes in your provided code to avoid duplicate definition
    public class UserLimiter
    {
        public string Password { get; set; }
        public int DailyTimeLimit { get; set; }
        public int DailyTimeExtra { get; set; }
    }

    public class UserSettingsLimiter
    {
        public Admin Admin { get; set; }
        public User User { get; set; }
    }


    public class GameData
    {
        public string GameName { get; set; }
        public object Groups { get; set; } // you may replace object with appropriate class
        public TimePlayedData TimePlayed { get; set; }
        public object StartDate { get; set; } // you can replace object with DateTime
        public string LastPlayed { get; set; }
    }

    public class TimePlayedData
    {
        public int today { get; set; }
        public int current_session { get; set; }
        public int this_month { get; set; } 
    }

}
