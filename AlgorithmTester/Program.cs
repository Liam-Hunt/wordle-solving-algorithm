using WordleAlgorithm;
using WordleAlgorithm.Algorithms;

var timesToTest = 10;

var wordles = File.ReadAllLines("testing-wordles.txt")
    .ToArray();

var guessingWords = File.ReadAllLines("words_alpha.txt");
//var guessingWords = File.ReadAllLines("Collins Scrabble Words (2019) Lowered.txt");

//var words = new List<string>();
//var rnd = new Random();

//while(words.Count() < 500)
//{
//    var word = guessingWords[rnd.Next(guessingWords.Length)];

//    if (!words.Contains(word))
//    {
//        words.Add(word);
//    }
//}

//File.AppendAllLines("C:/Users/Liam/Desktop/testing-words.txt", words);




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