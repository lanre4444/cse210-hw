using System;
using System.Collections.Generic;

/*
 * EXCEEDING REQUIREMENTS
 * 1. No repeated prompts or questions: the Reflecting and Listing activities
 *    randomly select prompts and questions without repeating an item until
 *    every item in the corresponding list has been used once.
 * 2. Session log: the program counts how many times each activity is run
 *    and displays a summary when the user quits.
 */
class Program
{
    static void Main(string[] args)
    {
        // Activity objects are created once so their "unused" lists persist.
        BreathingActivity breathing = new BreathingActivity();
        ReflectingActivity reflecting = new ReflectingActivity();
        ListingActivity listing = new ListingActivity();

        Dictionary<string, int> log = new Dictionary<string, int>
        {
            { breathing.GetName(), 0 },
            { reflecting.GetName(), 0 },
            { listing.GetName(), 0 }
        };

        string choice = "";

        while (choice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                breathing.Run();
                log[breathing.GetName()]++;
            }
            else if (choice == "2")
            {
                reflecting.Run();
                log[reflecting.GetName()]++;
            }
            else if (choice == "3")
            {
                listing.Run();
                log[listing.GetName()]++;
            }
        }

        Console.Clear();
        Console.WriteLine("Session summary:");
        foreach (KeyValuePair<string, int> entry in log)
        {
            Console.WriteLine($"  {entry.Key}: {entry.Value} time(s)");
        }
        Console.WriteLine("Goodbye!");
    }
}