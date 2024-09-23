
public class BubbleSorter
{
    public delegate bool SortCondition(int a, int b);

    public void Sort(int[] array, SortCondition condition)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (condition(array[j], array[j + 1]))
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }

    public void PrintArray(int[] array)
    {
        Console.WriteLine(string.Join(", ", array));
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 5, 3, 8, 4, 2 };

        BubbleSorter sorter = new BubbleSorter();

        BubbleSorter.SortCondition ascending = (a, b) => a > b;

        BubbleSorter.SortCondition descending = (a, b) => a < b;

        Console.WriteLine("Масив перед сортуванням:");
        sorter.PrintArray(array);

        Console.WriteLine("\nСортування за зростанням:");
        sorter.Sort(array, ascending);
        sorter.PrintArray(array);

        array = new int[] { 5, 3, 8, 4, 2 };

        Console.WriteLine("\nСортування за спаданням:");
        sorter.Sort(array, descending);
        sorter.PrintArray(array);
    }
}