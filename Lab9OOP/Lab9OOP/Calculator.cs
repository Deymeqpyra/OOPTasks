using System.Numerics;

namespace Lab9OOP;

public class Calculator<T> 
{
        public T Add(T a, T b)
        {
                return (T)Convert.ChangeType(Convert.ToDouble(a) + Convert.ToDouble(b), typeof(T));
        }

        public T Subtract(T a, T b)
        {
                return (T)Convert.ChangeType(Convert.ToDouble(a) - Convert.ToDouble(b), typeof(T));
        }

        public T Multiply(T a, T b)
        {
                return (T)Convert.ChangeType(Convert.ToDouble(a) * Convert.ToDouble(b), typeof(T));
        }
        public T Power(T a, T b)
        {
                return (T)Convert.ChangeType(Math.Pow(Convert.ToDouble(a), Convert.ToDouble(b)), typeof(T));
        }

        public T Divide(T a, T b)
        {
                if (Convert.ToDouble(b) == 0)
                {
                        throw new DivideByZeroException("Division by zero is not allowed.");
                }
                return (T)Convert.ChangeType(Convert.ToDouble(a) / Convert.ToDouble(b), typeof(T));
        }
}