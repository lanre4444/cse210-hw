using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": Console.WriteLine("Keep questing!"); break;
                default: Console.WriteLine("Please choose 1-6."); break;
            }
        }
    }

    private int GetLevel()
    {
        return Math.Max(1, (_score / 1000) + 1);
    }

    private string GetTitle()
    {
        int level = GetLevel();
        if (level >= 10) return "Eternal Champion";
        if (level >= 5) return "Valiant Knight";
        if (level >= 3) return "Brave Squire";
        return "Humble Apprentice";
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points. Level {GetLevel()} - {GetTitle()}");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        ListGoalNames();
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (bad habit)");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, description, points));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal first.");
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("That goal doesn't exist.");
            return;
        }

        int oldLevel = GetLevel();
        int earned = _goals[index].RecordEvent();
        _score += earned;

        if (earned > 0)
        {
            Console.WriteLine($"Congratulations! You have earned {earned} points!");
        }
        else if (earned < 0)
        {
            Console.WriteLine($"Ouch! You lost {-earned} points. Tomorrow is a new day.");
        }
        else
        {
            Console.WriteLine("That goal is already complete. No points awarded.");
        }

        if (GetLevel() > oldLevel)
        {
            Console.WriteLine($"*** LEVEL UP! You are now level {GetLevel()} - {GetTitle()}! ***");
        }

        Console.WriteLine($"You now have {_score} points.");
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] halves = lines[i].Split(':', 2);
            string type = halves[0];
            string[] p = halves[1].Split('|');

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(p[0], p[1], int.Parse(p[2]), bool.Parse(p[3])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(p[0], p[1], int.Parse(p[2])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(p[0], p[1], int.Parse(p[2]),
                        int.Parse(p[4]), int.Parse(p[3]), int.Parse(p[5])));
                    break;
                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(p[0], p[1], int.Parse(p[2])));
                    break;
            }
        }

        Console.WriteLine("Goals loaded.");
    }
}