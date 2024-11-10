using System.Numerics;

namespace Lab9OOP;

public class Calculator<T> where T : INumber<T>
{
    public T Add(T a, T b)
    {
        return (T)a + b;
    }

    public T Subtract(T a, T b)
    {
        return (T)a - b;
    }

    public T Multiply(T a, T b)
    {
        return (T)a * b;
    }

    public T Power(T a, T b)
    {
        T result = T.One;
        if (b == T.Zero)
        {
            return T.One;
        }

        for (T i = T.Zero; i < b; i++)
        {
            result *= a;
        }

        return result;
    }

    public T Divide(T a, T b)
    {
        if (b == T.Zero)
        {
            throw new DivideByZeroException("Division by zero is not allowed.");
        }

        return (T)a / b;
    }
}