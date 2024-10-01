public class Program
{
    public static void Main(string[] args)
    {
        var str = "a, 1, 2, f, -1, 0, 4, 10, 4, f, 4f, 8, 9, 3";
        
        var numbers = str.Split(',')
            .Select(s => {
                float number;
                return float.TryParse(s, out number) ? (float?)number : null;
            })
            .Where(n => n.HasValue)
            .Select(n => n.Value)
            .OrderBy(n => n)
            .Skip(3);

        var sum = numbers.Sum();
        Console.WriteLine(sum);
    }
}



