
using Labaratorna7OOP;

class Program
{
    static void Main()
    {
        var list = new UserGenericList<int>();

        Console.WriteLine("Adding elements...");
        list.AddFirst(10);
        list.AddLast(20);
        list.AddFirst(5);
        list.AddLast(25);
       
        Console.WriteLine("Current list:");
        list.DisplayList();

        Console.WriteLine($"Contains 20: {list.Contains(20)}"); 
        Console.WriteLine($"Contains 30: {list.Contains(30)}"); 

        Console.WriteLine($"Find 20: {list.Find(20)}");         
        Console.WriteLine($"FindLast 10: {list.FindLast(10)}"); 

        Console.WriteLine("\nRemoving elements...");
        list.Remove(10);   
        list.Remove(5);    
        list.Remove(25);
        
      
        Console.WriteLine("List after removals:");
        list.DisplayList();
        
        Console.WriteLine("\nClearing the list...");
        list.Clear();
        list.DisplayList();
        
        list.AddLast(50);
        list.AddLast(60);
        list.AddLast(70);

        Console.WriteLine("\nRemoving first and last elements...");
        list.RemoveFirst();  
        list.RemoveLast();  

        Console.WriteLine("List after RemoveFirst and RemoveLast:");
        list.DisplayList();

        Console.WriteLine($"\nFinal count of elements in list: {list.Count}");
    }
}
