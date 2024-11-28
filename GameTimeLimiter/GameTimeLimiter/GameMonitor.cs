using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Configuration;

namespace GameTimeLimiter
{
    public partial class GameMonitor : Form
    {
        private List<Game> gameList; // Define "gameList" here as a class member
        string gameDataPath;
        string userDataPath;

        public GameMonitor()
        {
            InitializeComponent();

            // Get game data and user data paths from App.config 
            userDataPath = ConfigurationManager.AppSettings["UserDataPath"];
            gameDataPath = ConfigurationManager.AppSettings["GameDataPath"];

            // Load and deserialize JSON data immediately after paths are loaded
            string jsonString = File.ReadAllText(gameDataPath);
            gameList = JsonSerializer.Deserialize<List<Game>>(jsonString);
        }


        private void GameMonitor_Load(object sender, EventArgs e)
        {
            // Switch off auto column generation
            dataGridView1.AutoGenerateColumns = false;

            // Flatten game properties
            var flatGames = gameList.Select(g => new
            {
                GameName = g.GameName,
                DaysPlayedToday = g.TimePlayed.today,
                DaysPlayedCurrentSession = g.TimePlayed.current_session,
                DaysPlayedThisMonth = g.TimePlayed.this_month,
                g.StartDate,
                g.LastPlayed
            }).ToList();

            // Put into data source
            BindingSource bs = new BindingSource();
            bs.DataSource = flatGames;
            this.dataGridView1.DataSource = bs;

            // Map the data to the DataGridView columns
            dataGridView1.Columns["games"].DataPropertyName = "GameName";
            dataGridView1.Columns["playtime_today"].DataPropertyName =
                "DaysPlayedToday"; // Note: You might need to adjust this.
            dataGridView1.Columns["playtime_week"].DataPropertyName =
                "DaysPlayedCurrentSession"; // Note: You might need to adjust this.
            dataGridView1.Columns["playtime_month"].DataPropertyName =
                "DaysPlayedThisMonth"; // Note: You might need to adjust this.
            dataGridView1.Columns["last_played"].DataPropertyName =
                "LastPlayed"; // Note: You might need to adjust this.
        }


        private void add_game_Click(object sender, EventArgs e)
        {
            var form = new AddGameForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                // Add new game to the list
                var newGame = new Game
                {
                    GameName = form.SelectedGame,
                    TimePlayed = new TimePlayed { today = 0, current_session = 0, this_month = 0 }
                    // Initialize other properties as needed
                };
                gameList.Add(newGame);

                // Rewrite the updated games list to the JSON file
                string newJsonString = JsonSerializer.Serialize(gameList);
                File.WriteAllText(gameDataPath, newJsonString);

                // Refresh DataGridView / Re-render table
                RefreshGamesList();
            }
        }

// Extract code to refresh the games list into a separate method
        private void RefreshGamesList()
        {
            var flatGames = gameList.Select(g => new
            {
                GameName = g.GameName,
                DaysPlayedToday = g.TimePlayed.today,
                DaysPlayedCurrentSession = g.TimePlayed.current_session,
                DaysPlayedThisMonth = g.TimePlayed.this_month,
                g.StartDate,
                g.LastPlayed
            }).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = flatGames;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            // If the clicked column is the Button column, and the row isn't the headers row
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Get the name of the game to remove
                string gameNameToDelete = senderGrid.Rows[e.RowIndex].Cells["GameName"].Value.ToString();
                // Remove the game from the list
                gameList.RemoveAll(g => g.GameName == gameNameToDelete);
                // Rewrite the updated games list to the JSON file
                string newJsonString = JsonSerializer.Serialize(gameList);
                File.WriteAllText(gameDataPath, newJsonString);
                // Refresh DataGridView / Re-render table
                var flatGames = gameList.Select(g => new
                {
                    GameName = g.GameName,
                    DaysPlayedToday = g.TimePlayed.today,
                    DaysPlayedCurrentSession = g.TimePlayed.current_session,
                    DaysPlayedThisMonth = g.TimePlayed.this_month,
                    g.StartDate,
                    g.LastPlayed
                }).ToList();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = flatGames;
            }
        }
    }

    public class Game
    {
        public string GameName { get; set; }
        public List<string> Groups { get; set; }
        public TimePlayed TimePlayed { get; set; }
        public string StartDate { get; set; }
        public string LastPlayed { get; set; }
    }

    public class TimePlayed
    {
        public double today { get; set; }
        public double current_session { get; set; }
        public double this_month { get; set; }
    }
}