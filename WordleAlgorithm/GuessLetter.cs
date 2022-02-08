namespace WordleAlgorithm
{
internal class GuessLetter
{
    public bool LetterInWordle { get; set; }
    public List<int> IncorrectPositions { get; set; }
    public int? CorrectPosition { get; set; }

    public readonly char Letter;

    public GuessLetter(char guessLetter)
    {
        Letter = guessLetter;
    }
}
}
