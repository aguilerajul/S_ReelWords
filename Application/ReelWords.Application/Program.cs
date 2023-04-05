// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReelWords.Domain.Contracts;
using ReelWords.Domain.Entities;
using ReelWords.Infrastructure;
using System.Text;

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
// starting game
startGame(host);

await host.RunAsync();

static T GetServiceInstance<T>(IServiceProvider hostProvider)
{
    using IServiceScope serviceScope = hostProvider.CreateScope();
    return hostProvider.GetRequiredService<T>();
}

static void startGame(IHost host)
{
    // Start the game
    bool playing = true;
    var totalScore = 0;
    // DI Provider Services
    var trieService = GetServiceInstance<ITrieService>(host.Services);
    var scoreService = GetServiceInstance<IScoreService>(host.Services);
    var reelService = GetServiceInstance<IReelsService>(host.Services);
    // Pre-Load Data
    var baseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;
    var trie = trieService.GenerateFromFile(baseDirectoryPath);
    var scores = scoreService.GenerateListFromFile(baseDirectoryPath).ToList();
    var reels = reelService.GenerateListFromFile(baseDirectoryPath).ToList();

    RulesAndWelcomeMessage(reels.Count());
    string playerWord = string.Empty;
    while (playing)
    {
        StringBuilder wordBuilder = GetReelWord(ref reels, playerWord);
        DisplayWordWithScore(scoreService, scores, wordBuilder.ToString());
        Console.WriteLine("-- Write your word --");
        playerWord = Console.ReadLine();
        GameSeparator();

        ValidatePlayerInput(ref playerWord);
        ValidatePlayerInputLettersWithCurrentReel(wordBuilder.ToString(), ref playerWord);
        ValidatePlayerInputInTrie(trie, ref playerWord);
        DisplayTotalPlayerScore(scoreService, scores, playerWord, ref totalScore);

        GameSeparator();
        Console.WriteLine("Excellent, let's go with another word");
        GameSeparator();
    }
}

static void WelcomeSeparator() => Console.WriteLine("==========================================================");
static void GameSeparator() => Console.WriteLine("-------------------------------------");
static void EmptyLine() => Console.WriteLine(" ");
static void TryAgainMessage() => Console.WriteLine($"So, let's try again with another one.");

static void RulesAndWelcomeMessage(int totalWords)
{
    Console.WriteLine("-- Welcome to this amazing ReelWord game! --");
    WelcomeSeparator();
    Console.WriteLine($"How to play: ");
    Console.WriteLine($"1.- You should create words based on those display it in the screen.");
    Console.WriteLine($"2.- The words used will be move it down.");
    Console.WriteLine($"3.- Under the words display it on the screen you will have the score per letter.");
    Console.WriteLine($"4.- Everytime that you create a new word you will have an score.");
    EmptyLine();
    Console.WriteLine($"-- Good luck and have fun!. --");
    WelcomeSeparator();
}

static void DisplayTotalPlayerScore(IScoreService scoreService, IList<Score> scores, string playerWord, ref int totalScore)
{
    var wordLettersScore = scoreService.GetWordScore(playerWord, scores).ToList();
    totalScore += wordLettersScore.Sum(ps => ps.Value);
    GameSeparator();
    Console.WriteLine($"Your current score:        {totalScore}");
    GameSeparator();
    EmptyLine();
}

static void DisplayWordWithScore(IScoreService scoreService, IList<Score> scores, string word)
{
    var wordLettersScore = scoreService.GetWordScore(word.Trim().Replace(" ", ""), scores).ToList();

    var stringBuilder = new StringBuilder();
    var textFormat = string.Empty;
    for (int i = 0; i < wordLettersScore.Count(); i++)
    {
        textFormat += $"{{{i},-2}}";
    }
    stringBuilder.AppendFormat(textFormat, wordLettersScore.Select(ps => ps.Value).Cast<object>().ToArray());

    GameSeparator();
    Console.WriteLine($"Word:  {word}");
    Console.WriteLine($"Score: {stringBuilder}");
    GameSeparator();
    EmptyLine();
}

static void ValidatePlayerInput(ref string playerWord)
{
    while (string.IsNullOrWhiteSpace(playerWord))
    {
        Console.WriteLine("Wrire your word");
        playerWord = Console.ReadLine();
        GameSeparator();
    }
}

static void ValidatePlayerInputLettersWithCurrentReel(string currentWord, ref string playerWord)
{
    var wrongLetters = new List<string>();
    var cleanWord = currentWord.Trim().Replace(" ", "");
    foreach (var c in playerWord)
    {
        if (!cleanWord.Contains(c))
        {
            wrongLetters.Add(c.ToString());
        }
    }

    if(wrongLetters.Count > 0)
    {
        Console.WriteLine($"There are some invalid letters: '{string.Join(", ", wrongLetters)}' that are not part of the reel.");
        TryAgainMessage();
        playerWord = null;
        ValidatePlayerInput(ref playerWord);
    }
}

static void ValidatePlayerInputInTrie(Trie trie, ref string playerWord)
{
    if (playerWord != null && !trie.Search(playerWord))
    {
        Console.WriteLine($"The word: '{playerWord}' is not registered as a valid word in our game.");
        TryAgainMessage();
        playerWord = null;
        GameSeparator();
        ValidatePlayerInput(ref playerWord);
    }
}

static StringBuilder GetReelWord(ref List<Reel> reels, string playerWord)
{
    StringBuilder wordBuilder = new StringBuilder();
    var letters = SetLettersPositions(ref reels, playerWord);

    foreach (var letter in letters.OrderBy(l => l.ColPosition))
    {
        wordBuilder.Append(letter.C.ToString());
        wordBuilder.Append(" ");
    }

    return wordBuilder;
}

static IEnumerable<Letter> SetLettersPositions(ref List<Reel> reels, string playerWord)
{
    var result = reels.SelectMany(r => r.Letters.Where(l => l.RowPosition == 0));
    if (!string.IsNullOrEmpty(playerWord))
    {
        var cleanedWord = playerWord.Trim().Replace(" ", "");
        var totalRows = reels.Count() - 1;
        foreach (var c in cleanedWord)
        {
            var lettersFound = result.Where(l => l.C == c).ToList().OrderBy(l => l.ColPosition);
            foreach (var letterFound in lettersFound)
            {
                reels.ForEach(r => r.Letters.ToList().ForEach(l =>
                {
                    if (l.ColPosition == letterFound.ColPosition)
                    {
                        var position = l.RowPosition >= totalRows ? 0 : l.RowPosition + 1;
                        l.SetRowPosition(position);
                    }
                }));
            }
        }
        result = reels.SelectMany(r => r.Letters.Where(l => l.RowPosition == 0));
    }
    return result;
}