namespace WordleAlgorithm
{
    public class SmartAlgorithm : IWordleAlgorithm
    {
        private readonly string[] _words;

        public SmartAlgorithm(string[] words)
        {
            this._words = words;
        }

        public int GuessWorld(string wordle)
        {
            var words = _words.Where(x => x.Length == wordle.Length).ToArray();

            var rnd = new Random();

            var guessState = new GuessState();

            var guesses = new List<string>();
            guesses.Add(words[rnd.Next(words.Length)]);

            while (guesses.Last() != wordle)
            {
                var results = WordComparer.Compare(wordle, guesses.Last());

                Console.WriteLine($"Guess #{guesses.Count()}: {guesses.Last()} " +
                    $"found {results.Where(x => x.FoundInWord).Count()} " +
                    $"letters: {string.Join(',', results.Where(x => x.FoundInWord).Select(x => x.Letter))}");

                guessState.AddGuessResults(results);

                words = words.Where(x => PotentialGuessValidator.Validate(x, guesses, guessState)).ToArray();

                guesses.Add(words[rnd.Next(words.Length)]);
            }

            Console.WriteLine($"Wordle guessed in {guesses.Count()} guesses!");

            return guesses.Count();
        }
    }
}
