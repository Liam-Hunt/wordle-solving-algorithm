namespace WordleAlgorithm.Algorithms
{
    public class BigBrainAlgorithm : IWordleAlgorithm
    {
        private readonly string[] _words;
        private Dictionary<char, Dictionary<int, int>> letterPositionalScores;
        private Dictionary<char, int> letterCommonalityScores = new Dictionary<char, int>
        {
            {'e', 26},
            {'a', 25},
            {'r', 24},
            {'i', 23},
            {'o', 22},
            {'t', 21},
            {'n', 20},
            {'s', 19},
            {'l', 18},
            {'c', 17},
            {'u', 16},
            {'d', 15},
            {'p', 14},
            {'m', 13},
            {'h', 12},
            {'g', 11},
            {'b', 10},
            {'f', 9},
            {'y', 8},
            {'w', 7},
            {'k', 6},
            {'v', 5},
            {'x', 4},
            {'z', 3},
            {'j', 2},
            {'q', 1 }
        };

        public BigBrainAlgorithm(string[] words)
        {
            this._words = words;
            letterPositionalScores = new Dictionary<char, Dictionary<int, int>>();

            foreach (var letter in letterCommonalityScores.Keys)
            {
                letterPositionalScores.Add(letter,
                    LetterMostCommonPositions.CalculateMostCommonPositionRanked(words, letter));
            }
        }

        public int GuessWorld(string wordle)
        {
            var words = _words.Where(x => x.Length == wordle.Length).ToArray();

            var guessState = new GuessState();

            var guesses = new List<string>();
            guesses.Add(GetRandomGuessWord(words));

            while (guesses.Last() != wordle)
            {
                var results = WordComparer.Compare(wordle, guesses.Last());

                Console.WriteLine($"Guess #{guesses.Count()}: {guesses.Last()} " +
                    $"found {results.Where(x => x.FoundInWord).Count()} " +
                    $"letters: {string.Join(',', results.Where(x => x.FoundInWord).Select(x => x.Letter))}");

                guessState.AddGuessResults(results);

                words = words.Where(x => PotentialGuessValidator.Validate(x, guesses, guessState))
                    .ToArray();

                guesses.Add(GetRandomGuessWord(words));
            }

            Console.WriteLine($"Wordle guessed in {guesses.Count()} guesses!");

            return guesses.Count();
        }

        private string GetRandomGuessWord(string[] words)
        {
            var rnd = new Random();

            var scoredWords = words
                .GroupBy(x => PotentialGuessScorer.Score(x, letterCommonalityScores, letterPositionalScores))
                .OrderByDescending(x => x.Key)
                .First()
                .ToArray();

            return scoredWords[rnd.Next(scoredWords.Length)];
        }
    }
}
