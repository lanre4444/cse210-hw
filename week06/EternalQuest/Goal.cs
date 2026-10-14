public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    protected string GetShortName()
    {
        return _shortName;
    }

    protected string GetDescription()
    {
        return _description;
    }

    protected int GetPoints()
    {
        return _points;
    }

    // Returns the points earned (or lost) for recording this goal
    public abstract int RecordEvent();

    public abstract bool IsComplete();

    // Saved to file as "TypeName:detail1|detail2|..."
    public abstract string GetStringRepresentation();

    public virtual string GetDetailsString()
    {
        string box = IsComplete() ? "[X]" : "[ ]";
        return $"{box} {_shortName} ({_description})";
    }
}