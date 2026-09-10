void DisplayWelcome()
{
    Console.WriteLine("Welcome to the Program!");
}

string PromptUserName()
{
    Console.Write("Please enter your name: ");
    string name = Console.ReadLine();
    return name;
}

int PromptUserNumber()
{
    Console.Write("Please enter your favorite number: ");
    int number = int.Parse(Console.ReadLine());
    return number;
}

int SquareNumber(int number)
{
    return number * number;
}

void DisplayResult(string name, int square)
{
    Console.WriteLine($"{name}, the square of your number is {square}");
}

// Main program
DisplayWelcome();

string name = PromptUserName();
int number = PromptUserNumber();

int square = SquareNumber(number);

DisplayResult(name, square);