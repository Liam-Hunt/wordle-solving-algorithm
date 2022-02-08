namespace WordleAlgorithm
{
    public class DumbAlgorithm : IWordleAlgorithm
    {
        private readonly string[] _words;

        public DumbAlgorithm(string[] words)
        {
            this._words = words;
        }

        public int GuessWorld(string wordle)
        {
            var words = _words
                .Where(x => x.Length == wordle.Length)
                .ToArray();

            var knownLetters = new List<char>();
            var guesses = new List<string>();
            var rnd = new Random();

            guesses.Add(words[rnd.Next(words.Length)]);

            while (guesses.Last() != wordle)
            {
                // Find which guess letters are contained in the Wordle
                var foundLetters = guesses.Last().Where(x => wordle.Contains(x));
                knownLetters.AddRange(foundLetters.Where(x => !knownLetters.Contains(x)));

                Console.WriteLine($"Guess #{guesses.Count()}: {guesses.Last()} " +
                    $"found {foundLetters.Count()} letters: {string.Join(',', foundLetters)}");

                // Filter our word choices for the next guess based on the known letters
                words = words.Where(x =>
                    knownLetters.All(y => x.Contains(y) &&
                    !guesses.Last().Contains(x))).ToArray();

                guesses.Add(words[rnd.Next(words.Length)]);
            }

            Console.WriteLine($"Wordle guessed in {guesses.Count()} guesses!");

            return guesses.Count();
        }
    }
}
