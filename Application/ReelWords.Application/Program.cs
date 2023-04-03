// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReelWords.Domain.Contracts;
using ReelWords.Domain.Entities;
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

// Load Data
var trie = new Trie();
LoadData(host.Services, trie);

// starting game
startGame();

await host.RunAsync();

static void LoadData(
    IServiceProvider hostProvider,
    Trie? trie
)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    var trieService = provider.GetRequiredService<ITrieService>();

    trie = trieService.GenerateFromFile($"{AppDomain.CurrentDomain.BaseDirectory}Resources\\american-english-large.txt");
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