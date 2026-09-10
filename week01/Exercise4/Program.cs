List<int> numbers = new List<int>();

Console.WriteLine("Enter a list of numbers, type 0 when finished.");

int number = -1;

while (number != 0)
{
    Console.Write("Enter number: ");
    number = int.Parse(Console.ReadLine());

    if (number != 0)
    {
        numbers.Add(number);
    }
}

int sum = 0;

foreach (int item in numbers)
{
    sum += item;
}

double average = (double)sum / numbers.Count;

int largest = numbers[0];

foreach (int item in numbers)
{
    if (item > largest)
    {
        largest = item;
    }
}

// Stretch Challenge 1: Find the smallest positive number
int smallestPositive = int.MaxValue;

foreach (int item in numbers)
{
    if (item > 0 && item < smallestPositive)
    {
        smallestPositive = item;
    }
}

// Stretch Challenge 2: Sort the list
numbers.Sort();

Console.WriteLine($"The sum is: {sum}");
Console.WriteLine($"The average is: {average}");
Console.WriteLine($"The largest number is: {largest}");
Console.WriteLine($"The smallest positive number is: {smallestPositive}");

Console.WriteLine("The sorted list is:");

foreach (int item in numbers)
{
    Console.WriteLine(item);
}