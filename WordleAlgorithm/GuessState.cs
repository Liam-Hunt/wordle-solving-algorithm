namespace WordleAlgorithm
{
    internal class GuessState
    {
        public List<GuessLetter> guessInfo { get; private set; }
        
        public GuessState()
        {
            this.guessInfo = new List<GuessLetter>();
        }

        public void AddGuessResults(IEnumerable<LetterResult> guessResults)
        {
            foreach (var result in guessResults)
            {
                if (!guessInfo.Any(x => x.Letter == result.Letter))
                {
                    guessInfo.Add(new GuessLetter(result.Letter)
                    {
                        LetterInWordle = result.FoundInWord,
                        CorrectPosition = result.RightPosition ? result.Position : null,
                        IncorrectPositions = result.RightPosition ? new List<int>() : new List<int> { result.Position }
                    });
                }
                else
                {
                    var guessLetter = guessInfo.Single(x => x.Letter.Equals(result.Letter));

                    if (result.RightPosition)
                    {
                        guessLetter.CorrectPosition = result.Position;
                    }
                    else
                    {
                        guessLetter.IncorrectPositions.Add(result.Position);
                    }
                }
            }
        }
    }
}
