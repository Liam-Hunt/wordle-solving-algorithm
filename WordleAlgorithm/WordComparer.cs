namespace WordleAlgorithm
{
    internal static class WordComparer
    {
        public static IEnumerable<LetterResult> Compare(string wordle, string guess)
        {
            var results = new List<LetterResult>();

            for (int i = 0; i < guess.Length; i++)
            {
                var result = new LetterResult
                {
                    Letter = guess[i],
                    Position = i,
                };

                for (int wI = 0; wI < wordle.Length; wI++)
                {
                    if (guess[i] == wordle[wI])
                    {
                        result.FoundInWord = true;

                        if (i == wI)
                        {
                            result.RightPosition = true;
                        }
                    }
                }

                results.Add(result);
            }

            return results;
        }
    }
}
