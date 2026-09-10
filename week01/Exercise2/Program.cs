Console.Write("What is your grade percentage? ");
int grade = int.Parse(Console.ReadLine());

string letter;

// Determine the letter grade
if (grade >= 90)
{
    letter = "A";
}
else if (grade >= 80)
{
    letter = "B";
}
else if (grade >= 70)
{
    letter = "C";
}
else if (grade >= 60)
{
    letter = "D";
}
else
{
    letter = "F";
}

// Stretch Challenge 1: Determine the + or - sign
string sign = "";

int lastDigit = grade % 10;

if (lastDigit >= 7)
{
    sign = "+";
}
else if (lastDigit < 3)
{
    sign = "-";
}

// Stretch Challenge 2: There is no A+
if (letter == "A" && sign == "+")
{
    sign = "";
}

// Stretch Challenge 3: There is no F+ or F-
if (letter == "F")
{
    sign = "";
}

// Display the final grade
Console.WriteLine($"Your grade is: {letter}{sign}");

// Determine whether the student passed
if (grade >= 70)
{
    Console.WriteLine("Congratulations! You passed the course.");
}
else
{
    Console.WriteLine("Keep working hard. You can do better next time.");
}