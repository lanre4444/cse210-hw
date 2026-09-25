public class Word
{
    private string _text;
    private bool _isHidden;

    // A new word is visible by default
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    // Returns the word, or underscores (one per letter) if hidden.
    // Punctuation such as commas and apostrophes stays visible.
    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        string display = "";
        foreach (char c in _text)
        {
            display += char.IsLetter(c) ? '_' : c;
        }
        return display;
    }
}