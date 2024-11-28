public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly GameService _gameService;
    private readonly UserService _userService;
    
    public Worker(ILogger<Worker> logger, GameService gameService, UserService userService)
    {
        _logger = logger;
        _gameService = gameService;
        _userService = userService;
        _logger.LogInformation("Worker initialized!");
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker started execution!");
        
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
           
            _logger.LogInformation("Calling MonitorGameTime!");
            await _gameService.MonitorGameTime(stoppingToken);
            _logger.LogInformation("Finished calling MonitorGameTime!");
            
            _logger.LogInformation("Calling CheckMaxPlayTime!");
            await _userService.CheckMaxPlayTime("User");
            _logger.LogInformation("Finished calling CheckMaxPlayTime!");
            
            _logger.LogInformation("Worker is going to sleep for 60 seconds...");
            await Task.Delay(60000, stoppingToken);
            _logger.LogInformation("Worker woke up!");
        }

        _logger.LogInformation("Worker execution has been requested to stop!");
    }
}