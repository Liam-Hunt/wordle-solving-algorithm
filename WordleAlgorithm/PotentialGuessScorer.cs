using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleAlgorithm
{
    internal static class PotentialGuessScorer
    {
        public static int Score(string guess,
            Dictionary<char, int> letterCommonalityScores,
            Dictionary<char, Dictionary<int, int>> letterPositionalScores)
        {
            var score = 0;

            var usedLetters = new List<char>();

            for (int i = 0; i < guess.Length; i++)
            {
                // Only score each letter once otherwise we end up
                // with a word full of 'e's
                if (!usedLetters.Contains(guess[i]))
                {
                    score = score + letterCommonalityScores[guess[i]];
                }

                score = score + letterPositionalScores[guess[i]][i];

                usedLetters.Add(guess[i]);
            }

            return score;
        }
    }
}
