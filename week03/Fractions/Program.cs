using System;

class Program
{
    static void Main(string[] args)
    {
        // Verify all three constructors
        Fraction f1 = new Fraction();      // 1/1
        Fraction f2 = new Fraction(5);     // 5/1
        Fraction f3 = new Fraction(3, 4);  // 3/4
        Fraction f4 = new Fraction(1, 3);  // 1/3

        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        // Verify getters and setters
        Fraction f5 = new Fraction(6, 7);
        Console.WriteLine($"Before: {f5.GetTop()} / {f5.GetBottom()}");
        f5.SetTop(2);
        f5.SetBottom(9);
        Console.WriteLine($"After: {f5.GetTop()} / {f5.GetBottom()}");
        Console.WriteLine(f5.GetFractionString());
        Console.WriteLine(f5.GetDecimalValue());
    }
}