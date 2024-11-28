using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Configuration;

namespace GameTimeLimiter
{
    public class GameTimeMonitorService : BackgroundService
    {
        private string userDataPath = ConfigurationManager.AppSettings["UserDataPath"]; // Replace with your path to UserData.Json
        private string gameDataPath = ConfigurationManager.AppSettings["GameDataPath"];
        private List<GameModel> gameList;
        private List<ProcessSession> activeSessions;

        public GameTimeMonitorService()
        {
            gameList = new List<GameModel>();
            activeSessions = new List<ProcessSession>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Load games from JSON
                string jsonString = File.ReadAllText(gameDataPath);
                gameList = JsonSerializer.Deserialize<List<GameModel>>(jsonString);

                // If there is an active session, check only this game, otherwise, iterate through all games
                var activeGame = activeSessions.Select(s => gameList.FirstOrDefault(g => g.GameName == s.GameName)).FirstOrDefault();

                if (activeGame != null)
                {
                    await CheckGameProcess(activeGame, stoppingToken);
                }
                else
                {
                    foreach (var game in gameList)
                    {
                        await CheckGameProcess(game, stoppingToken);
                    }
                }

                // Wait for 5 seconds before checking the game status again
                await Task.Delay(5000, stoppingToken);
            }
        }

        private async Task CheckGameProcess(GameModel game, CancellationToken stoppingToken)
        {
            Process[] processes = Process.GetProcessesByName(game.GameName);

            if (processes.Length > 0 && !stoppingToken.IsCancellationRequested)
            {
                // If game is running and has no active session, start a new session
                if (!activeSessions.Any(s => s.GameName == game.GameName))
                {
                    activeSessions.Add(new ProcessSession { GameName = game.GameName, StartTime = DateTime.Now });
                }
            }
            else
            {
                // If game is not running but has an active session, end it and update game playtime
                var session = activeSessions.FirstOrDefault(s => s.GameName == game.GameName);

                if (session != null)
                {
                    var sessionDuration = DateTime.Now - session.StartTime;
                    game.TimePlayed.current_session += sessionDuration.TotalSeconds;
                    game.TimePlayed.today += sessionDuration.TotalSeconds;
                    game.TimePlayed.this_month += sessionDuration.TotalSeconds;

                    activeSessions.Remove(session);
                }
            }

            // Save updated games to JSON
            string newJsonString = JsonSerializer.Serialize(gameList);
            File.WriteAllText(gameDataPath, newJsonString);

            await Task.CompletedTask;
        }
    }

    public class ProcessSession
    {
        public string GameName { get; set; }
        public DateTime StartTime { get; set; }
    }

    public class GameModel
    {
        public string GameName { get; set; }
        public TimePlayedModel TimePlayed { get; set; }
    }

    public class TimePlayedModel
    {
        public double current_session { get; set; }
        public double today { get; set; }
        public double this_month { get; set; }
    }
}
