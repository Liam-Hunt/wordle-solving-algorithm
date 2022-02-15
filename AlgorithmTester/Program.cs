using WordleAlgorithm;
using WordleAlgorithm.Algorithms;

var timesToTest = 10;

var wordles = File.ReadAllLines("testing-wordles.txt")
    .ToArray();

var guessingWords = File.ReadAllLines("words_alpha.txt");

var algorithm = new BigBrainAlgorithm(guessingWords);

var algorithmResults = new List<int>();

var count = 0;
foreach (var wordle in wordles)
{
    Console.WriteLine(count);

    for (int i = 0; i < timesToTest; i++)
    {
        algorithmResults.Add(algorithm.GuessWorld(wordle));
    }

    count++;
}

Console.WriteLine($"Completed {algorithmResults.Count()} worlds using an average of {(double)algorithmResults.Sum() / (double)algorithmResults.Count()} guesses");

Console.ReadLine();