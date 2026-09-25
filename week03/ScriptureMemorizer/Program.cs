using System;

// EXCEEDING REQUIREMENTS:
// 1. Library of scriptures: a ScriptureLibrary class holds many scriptures and picks one at random each run.
// 2. Load from a file: scriptures are read from scriptures.txt (Book|Chapter|Verse or Range|Text);
//    if the file is missing or empty, built-in scriptures are used instead.
// 3. Stretch challenge: HideRandomWords only chooses words that are not already hidden.
// 4. Hidden words keep their punctuation (commas, apostrophes), and underscores match the letter count.
class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary("scriptures.txt");
        Scripture scripture = library.GetRandomScripture();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine();
            Console.Write("Press enter to continue or type 'quit' to finish: ");
            string input = Console.ReadLine() ?? "quit";

            if (input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}