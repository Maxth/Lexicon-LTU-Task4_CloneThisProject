using System.Collections.ObjectModel;
using System.Text;

static class Utils
{
    public static void PrintListDetails<T>(List<T> list)
    {
        System.Console.WriteLine($"List capacity: {list.Capacity}");
        System.Console.WriteLine($"List count: {list.Count}");
    }

    public static void PrintCollectionDetails<T>(IEnumerable<T> queue)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var item in queue)
        {
            sb.Append(item + " ");
        }

        System.Console.WriteLine($"Queue items: {sb}");
        // System.Console.WriteLine($"Queue count: {queue.}");
    }
}
