static class Utils
{
    public static void PrintListDetails<T>(List<T> list)
    {
        System.Console.WriteLine($"List capacity: {list.Capacity}");
        System.Console.WriteLine($"List count: {list.Count}");
    }
}
