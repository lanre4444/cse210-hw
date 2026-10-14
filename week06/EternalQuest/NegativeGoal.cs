public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return -GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[!] {GetShortName()} ({GetDescription()}) -- Costs {GetPoints()} points";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{GetShortName()}|{GetDescription()}|{GetPoints()}";
    }
}