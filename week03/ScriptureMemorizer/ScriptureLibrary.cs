using System;
using System.Collections.Generic;
using System.IO;

// Holds a collection of scriptures and hands one out at random.
// Loads from a text file (one scripture per line) and falls back to built-in scriptures.
// File line format:  Book|Chapter|Verse or Verse-Range|Text
// Example:           Proverbs|3|5-6|Trust in the Lord with all thine heart...
public class ScriptureLibrary
{
    private List<Scripture> _scriptures = new List<Scripture>();
    private Random _random = new Random();

    public ScriptureLibrary(string filePath)
    {
        if (File.Exists(filePath))
        {
            LoadFromFile(filePath);
        }

        if (_scriptures.Count == 0)
        {
            AddDefaultScriptures();
        }
    }

    public Scripture GetRandomScripture()
    {
        return _scriptures[_random.Next(_scriptures.Count)];
    }

    private void LoadFromFile(string filePath)
    {
        foreach (string line in File.ReadAllLines(filePath))
        {
            string[] parts = line.Split('|');
            if (parts.Length != 4)
            {
                continue; // skip blank or malformed lines
            }

            string book = parts[0].Trim();
            string text = parts[3].Trim();
            if (!int.TryParse(parts[1].Trim(), out int chapter))
            {
                continue;
            }

            string[] verses = parts[2].Trim().Split('-');
            Reference reference;
            if (verses.Length == 1 && int.TryParse(verses[0], out int verse))
            {
                reference = new Reference(book, chapter, verse);
            }
            else if (verses.Length == 2 && int.TryParse(verses[0], out int start) && int.TryParse(verses[1], out int end))
            {
                reference = new Reference(book, chapter, start, end);
            }
            else
            {
                continue;
            }

            _scriptures.Add(new Scripture(reference, text));
        }
    }

    private void AddDefaultScriptures()
    {
        _scriptures.Add(new Scripture(
            new Reference("John", 3, 16),
            "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));

        _scriptures.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6),
            "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));

        _scriptures.Add(new Scripture(
            new Reference("2 Nephi", 32, 3),
            "Angels speak by the power of the Holy Ghost; wherefore, they speak the words of Christ. Wherefore, I said unto you, feast upon the words of Christ; for behold, the words of Christ will tell you all things what ye should do."));
    }
}