using System;

// EXCEEDING REQUIREMENTS:
// 1. Leveling system: every 1,000 points raises your level, with titles
//    (Humble Apprentice -> Brave Squire -> Valiant Knight -> Eternal Champion)
//    and a "LEVEL UP!" message when you cross a threshold.
// 2. Negative goals: a fourth goal type for bad habits. Recording one
//    subtracts points. It is saved and loaded like the other goals.
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}