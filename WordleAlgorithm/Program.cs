using WordleAlgorithm.Algorithms;

var guessingWords = File.ReadAllLines("words_alpha.txt");

while (true)
{
    //var algorithm = new DumbAlgorithm(guessingWords);
    //var algorithm = new SmartAlgorithm(guessingWords);
    var algorithm = new BigBrainAlgorithm(guessingWords);

    Console.WriteLine("Please enter a wordle:");
    var wordle = Console.ReadLine();

    algorithm.GuessWorld(wordle);
}

Console.ReadLine();