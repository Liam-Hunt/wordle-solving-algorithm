namespace WordleAlgorithm
{
    public class LetterCounter
    {
        public Dictionary<char, int> Count(string[] words)
        {
            var buckets = new Dictionary<char, int>
            {
                {'a', 0},
                {'b', 0},
                {'c', 0},
                {'d', 0},
                {'e', 0},
                {'f', 0},
                {'g', 0},
                {'h', 0},
                {'i', 0},
                {'j', 0},
                {'k', 0},
                {'l', 0},
                {'m', 0},
                {'n', 0},
                {'o', 0},
                {'p', 0},
                {'q', 0},
                {'r', 0},
                {'s', 0},
                {'t', 0},
                {'u', 0},
                {'v', 0},
                {'w', 0},
                {'x', 0},
                {'y', 0},
                {'z', 0},
            };

            Console.WriteLine($"{words.Count()} words");

            var count = 0;

            foreach (var word in words)
            {
                foreach (var letter in word)
                {
                    buckets[letter]++;
                }

                count++;

                if (count % 1000 == 0)
                {
                    Console.WriteLine($"{count} words done");
                }
            }

            foreach (var bucket in buckets.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{bucket.Key} - {bucket.Value}");
            }

            return buckets;
        }
    }
}
