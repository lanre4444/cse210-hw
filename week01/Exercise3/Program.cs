string playAgain = "yes";

while (playAgain == "yes")
{
    Random random = new Random();
    int magicNumber = random.Next(1, 101);

    int guess = -1;
    int guessCount = 0;

    while (guess != magicNumber)
    {
        Console.Write("What is your guess? ");
        guess = int.Parse(Console.ReadLine());
        guessCount++;

        if (guess < magicNumber)
        {
            Console.WriteLine("Higher");
        }
        else if (guess > magicNumber)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine("You guessed it!");
        }
    }

    Console.WriteLine($"You guessed it in {guessCount} guesses.");

    Console.Write("Would you like to play again? ");
    playAgain = Console.ReadLine().ToLower();
}