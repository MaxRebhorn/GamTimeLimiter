using System.Diagnostics;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System;
public class UserService
{
    private readonly IConfiguration _configuration;
    private string _userDataPath;
    private string _gameDataPath;
    private string _gameTimeLimiterPath;

    public UserService(IConfiguration configuration)
    {
        _configuration = configuration;
        _userDataPath = _configuration.GetValue<string>("UserDataPath");
        _gameDataPath = _configuration.GetValue<string>("GameDataPath");
        _gameTimeLimiterPath = configuration.GetValue<string>("GameTimeLimiterPath");
    }

    public async Task<bool> CheckMaxPlayTime(string username)
    {
        var userDictionary = GetUserDictionary();
    
        if (!userDictionary.TryGetValue(username, out var userDetails))
            throw new Exception("User not found.");

        // Get the total playtime today from all games (in minutes)
        var totalPlayTimeToday = GetTotalPlayTimeToday();

        int? dailyLimitInHours = userDetails.DailyTimeLimit;

        if (dailyLimitInHours.HasValue)
        {
            // Convert hours to minutes 
            int dailyLimitInMinutes = dailyLimitInHours.Value * 60;

            if (totalPlayTimeToday > dailyLimitInMinutes)
            {
                Console.WriteLine("Starting Game Time Limiter.");
                StartGameTimeLimiter();
                return false;
            }
        }

        return true;
    }
    private void StartGameTimeLimiter()
    {
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = _gameTimeLimiterPath;
        startInfo.Arguments = "game_time_over";
        Process.Start(startInfo);
    }
    private int GetTotalPlayTimeToday()
    {
        string jsonString = File.ReadAllText(_gameDataPath);
        var gameList = JsonSerializer.Deserialize<List<GameDetail>>(jsonString);

        var totalPlayTimeToday = gameList.Sum(g => g.TimePlayed.today);
    
        return totalPlayTimeToday;
    }


    private Dictionary<string, UserDetail> GetUserDictionary()
    {
        string jsonString = File.ReadAllText(_userDataPath);
        var userDict = JsonSerializer.Deserialize<Dictionary<string, UserDetail>>(jsonString);
        return userDict;
    }
}
public class UserDetail
{
    public string Password { get; set; }
    public int? DailyTimeLimit { get; set; }
}
