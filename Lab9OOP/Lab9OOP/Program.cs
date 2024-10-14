using System.Runtime.InteropServices.ComTypes;
using Lab9OOP;

public class Program
{
    public static void Main(string[] args)
    {
        var rand = new Random();
        dynamic a = rand.Next(0,10);
        dynamic b = rand.Next(0,10);
        Console.WriteLine($"A: {a}, B: {b}");
        Console.WriteLine("Integer calculator");
        IntegerCalculator(a,b);
        
        a = rand.NextDouble();
        b = rand.NextDouble();
        Console.WriteLine("Double calculator");
        Console.WriteLine($"A: {a:N1}, B: {b:N1}");
        DoubleCalculator(a,b);
    }

    public static void IntegerCalculator(int a, int b)
    {
        var calc = new Calculator<int>();
       
        Console.WriteLine(calc.Add(a, b)); 
        Console.WriteLine(calc.Subtract(a, b)); 
        Console.WriteLine(calc.Multiply(a, b)); 
        Console.WriteLine(calc.Divide(a, b)); 
        Console.WriteLine(calc.Power(a, b)); 
    }

    public static void DoubleCalculator(double a, double b)
    {
        var calc = new Calculator<double>();
        
        Console.WriteLine($"{calc.Add(a, b):N1}"); 
        Console.WriteLine($"{calc.Subtract(a, b):N1}"); 
        Console.WriteLine($"{calc.Multiply(a, b):N1}"); 
        Console.WriteLine($"{calc.Divide(a, b):N1}"); 
        Console.WriteLine($"{calc.Power(a, b):N1}"); 
    }
}