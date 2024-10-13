namespace Lab9OOP;

public class Calculator<T> 
{
        public T Add(T valueA, T valueB)
        {
                dynamic a = valueA;
                dynamic b = valueB;
                return (T)a + b;
        }

        public T Substract(T valueA, T valueB)
        {
                dynamic a = valueA;
                dynamic b = valueB;
                return (T)a - b;
        }
        public T Multiply(T valueA, T valueB)
        {
                dynamic a = valueA;
                dynamic b = valueB;
                return (T)a * b;
        }

        public T Divide(T valueA, T valueB)
        {
                dynamic a = valueA;
                dynamic b = valueB;
                if (b == 0)
                { 
                        return (T)Convert.ChangeType(0, typeof(T));
                }

                return (T)a / b;
        }

        public T Power(T value, T valueToPower)
        {
                dynamic a = value;
                dynamic b = valueToPower;
                return (T)Math.Pow(a, b);
        }
}