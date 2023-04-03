// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReelWords.Domain.Contracts;
using ReelWords.Infrastructure;

// Build Configuration
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

// Add Dependency Injection
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddInfrastructure(config);
    })
    .Build();

// DI Provider
// var provider = GetProvider(host.Services);
var trieService = GetService<ITrieService>(host.Services);
var scoreService = GetService<IScoreService>(host.Services);
var reelService = GetService<IReelsService>(host.Services);

// Pre-Load Data
var baseDirectoryPath = $"{AppDomain.CurrentDomain.BaseDirectory}Resources";
var trie = trieService.GenerateFromFile($"{baseDirectoryPath}\\american-english-large.txt");
var scores = scoreService.GenerateListFromFile($"{baseDirectoryPath}\\scores.txt");
var reels = reelService.GenerateListFromFile($"{baseDirectoryPath}\\reels.txt");

// starting game
startGame();

await host.RunAsync();

static T GetService<T>(IServiceProvider hostProvider)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    return hostProvider.GetRequiredService<T>();
}

static void startGame()
{
    // Start the game
    bool playing = true;

    while (playing)
    {
        string input = Console.ReadLine();

        // TODO:  Run game logic here using the user input string

        // TODO:  Create simple unit tests to test your code in the ReelWordsTests project,
        // don't worry about creating tests for everything, just important functions as
        // seen for the Trie tests
    }
}