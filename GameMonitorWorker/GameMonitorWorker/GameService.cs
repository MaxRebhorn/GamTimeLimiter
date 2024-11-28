using System.Diagnostics;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System;

public class GameService
{
    private IConfiguration _configuration;
    private string _gameDataPath;
    private List<GameDetail> gameList;
    private List<GamingSession> activeSessions;

    public GameService(IConfiguration configuration)
    {
        Console.WriteLine("Starting GameService");
        _configuration = configuration;
    
        _gameDataPath = _configuration.GetValue<string>("GameDataPath");
    
        gameList = new List<GameDetail>();
        activeSessions = new List<GamingSession>();
    }

    public async Task CheckGameProcess(GameDetail game, CancellationToken stoppingToken)
    {
        Console.WriteLine($"Checking for game: {game.GameName}. Stopping token is cancellation requested: {stoppingToken.IsCancellationRequested}");
    
        Process[] processes = Process.GetProcessesByName(game.GameName);
        Console.WriteLine($"{processes.Length} processes found named {game.GameName}");
    
        if (processes.Length > 0 && !stoppingToken.IsCancellationRequested)
        {
            Console.WriteLine("Game process detected and stopping token not cancellation requested");
            var session = activeSessions.FirstOrDefault(s => s.GameName == game.GameName);
        
            if (session == null)
            {
                session = new GamingSession
                {
                    GameName = game.GameName,
                    StartTime = DateTime.Now,
                    PlayTime = TimeSpan.Zero
                };
                activeSessions.Add(session);
                Console.WriteLine("New game session started");
            }
        
            var sessionDuration = DateTime.Now - session.StartTime;
            var sessionDurationMinutes = (int)sessionDuration.TotalMinutes;
        
            Console.WriteLine($"{session.GameName} session duration {sessionDurationMinutes} minutes");
        
            // Save the current session's duration in the 'current_session' property and save playtime
            GameDetail gameInList = gameList.First(g => g.GameName == session.GameName);
            gameInList.TimePlayed.current_session = sessionDurationMinutes;
            await SavePlaytime(gameInList);
        }
        else
        {
            Console.WriteLine("No game processes found or stopping token cancellation requested");
            var session = activeSessions.FirstOrDefault(s => s.GameName == game.GameName);
        
            if (session != null)
            {
                activeSessions.Remove(session);
                Console.WriteLine("Game session ended");
            }
        }
    }



    private async Task SavePlaytime(GameDetail updatedGame)
    {
        Console.WriteLine($"Starting to Save Playtime for game: {updatedGame.GameName}");

        int index = gameList.FindIndex(g => g.GameName == updatedGame.GameName);

        if (index != -1)
        {
            Console.WriteLine($"Game {updatedGame.GameName} found at index {index}.");
            gameList[index] = updatedGame;
        }
        else
        {
            Console.WriteLine($"Game {updatedGame.GameName} was not found in list.");
            return; // Don't continue with save if game is not being tracked.
        }

        string jsonString = JsonSerializer.Serialize(gameList);
        Console.WriteLine($"Serialized game list to JSON: {jsonString}");

        await File.WriteAllTextAsync(_gameDataPath, jsonString);

        Console.WriteLine("Saved Game Data");
    }


    public async Task MonitorGameTime(CancellationToken stoppingToken)
    {
        Console.WriteLine("Starting MonitorGameTime");

        string jsonString = File.ReadAllText(_gameDataPath);
        Console.WriteLine("Read game data from file");

        gameList = JsonSerializer.Deserialize<List<GameDetail>>(jsonString);
        Console.WriteLine("Deserialized game data");

        List<GameDetail> tempList = new List<GameDetail>(gameList);

        DateTime dtToday = DateTime.Today;

        foreach (var game in tempList)
        {
            DateTime dtLastPlayed = DateTime.Parse(game.LastPlayed);
            if (dtToday.Date != dtLastPlayed.Date) // If today is a new day
            {
                game.TimePlayed.today = 0; // reset today's played time 
            }

            Console.WriteLine($"Checking game process: {game.GameName}");
            await CheckGameProcess(game, stoppingToken);
        }

        var activeGame = activeSessions.Select(s => gameList.FirstOrDefault(g => g.GameName == s.GameName))
            .FirstOrDefault();

        if (activeGame != null)
        {
            Console.WriteLine($"Active game found: {activeGame.GameName}");
            await CheckGameProcess(activeGame, stoppingToken);
        }
        else
        {
            Console.WriteLine("No active game found");
        }
    }
}

public class GameDetail
{
    public string GameName { get; set; }
    public List<string> Groups { get; set; }
    public TimePlayed TimePlayed { get; set; }
    public string StartDate { get; set; }
    public string LastPlayed { get; set; }
}

public class GamingSession
{
    public string GameName { get; set; }
    public DateTime StartTime { get; set; }
    public TimeSpan PlayTime { get; set; }
}

public class TimePlayed
{
    public int today { get; set; }
    public int current_session { get; set; }
    public int this_month { get; set; }
}