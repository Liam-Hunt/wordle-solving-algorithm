using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleAlgorithm
{
    internal static class PotentialGuessValidator
    {
        public static bool Validate(string potentialGuess, List<string> previousGuesses, GuessState guessState)
        {
            if (previousGuesses.Contains(potentialGuess))
            {
                return false;
            }

            foreach (var guessLetter in guessState.guessInfo)
            {
                if (guessLetter.LetterInWordle && !potentialGuess.Contains(guessLetter.Letter))
                {
                    return false;
                }

                if (!guessLetter.LetterInWordle && potentialGuess.Contains(guessLetter.Letter))
                {
                    return false;
                }

                if (guessLetter.CorrectPosition != null && potentialGuess[guessLetter.CorrectPosition.Value] != guessLetter.Letter)
                {
                    return false;
                }

                foreach (var incorrectPosition in guessLetter.IncorrectPositions)
                {
                    if (potentialGuess[incorrectPosition] == guessLetter.Letter)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
