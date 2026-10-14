using System;

// EXCEEDING REQUIREMENTS:
// Added a player leveling system with titles and level-up notifications.
// Added Negative Goals to deduct points for bad habits, with support
// for saving and loading goal data.
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}