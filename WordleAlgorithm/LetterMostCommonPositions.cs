namespace WordleAlgorithm
{
    internal static class LetterMostCommonPositions
    {
        public static Dictionary<int, int> CalculateMostCommonPositionRanked(IEnumerable<string> words, char letter)
        {
            var results = CalculateMostCommonPosition(words, letter);

            var rankedResults = new Dictionary<int, int>();

            var rank = results.Count();
            foreach (var result in results.OrderByDescending(x => x.Value))
            {
                rankedResults.Add(result.Key, rank);

                rank--;
            }

            return rankedResults;
        }

        public static Dictionary<int, double> CalculateMostCommonPosition(IEnumerable<string> words, char letter)
        {
            var positions = new Dictionary<int, int>();

            foreach (var word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == letter)
                    {
                        positions.TryAdd(i, 0);
                        positions[i]++;
                    }
                }
            }

            var total = positions.Sum(x => x.Value);

            return new Dictionary<int, double>(
                positions.Select(x =>
                new KeyValuePair<int, double>(x.Key, ((double)x.Value / total) * 100)));
        }
    }
}
