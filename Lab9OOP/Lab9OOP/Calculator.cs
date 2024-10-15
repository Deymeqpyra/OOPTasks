
using System.Numerics;

namespace Lab9OOP;

public class Calculator<T> where T : INumber<T>
{
        public T Add(T a, T b)
        {
                return (T)Convert.ChangeType(Convert.ToDouble(a) + Convert.ToDouble(b), typeof(T));
        }

        public T Subtract(T a, T b)
        {
                return (T)a-b;
        }

        public T Multiply(T a, T b)
        {
                return (T)a*b;
        }
        public T Power(T a, T b)
        {
                T result = T.One;
                for (T i = T.Zero; i < b; i++)
                {
                        result *= a;
                }
                return result;
        }
        public T Divide(T a, T b)
        {
                if (Convert.ToDouble(b) == 0)
                {
                        throw new DivideByZeroException("Division by zero is not allowed.");
                }
                return (T)a/b;
        }
}