namespace Labaratorna7OOP;

public static class UserGenericListExtension
{
    public static void DisplayList<T>(this UserGenericList<T> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("The list is empty.");
        }
        else
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}