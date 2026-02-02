namespace Polyfill.Example.IndexRange;

internal sealed class Program
{
    private static void Main()
    {
        Console.WriteLine("Index and Range polyfill examples (net48)");

        int[] arr = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
        Console.WriteLine($"Array: {string.Join(", ", arr)}");

        // Index
        int last = arr[^1];
        Console.WriteLine($"Last element (arr[^1]): {last}");

        // Range
        int[] slice = arr.AsSpan()[1..4].ToArray();
        Console.WriteLine($"Slice [1..4]: {string.Join(", ", slice)}");

        // from start / to end
        int[] head = arr.AsSpan()[..2].ToArray();
        Console.WriteLine($"Head [..2]: {string.Join(", ", head)}");
        int[] tail = arr.AsSpan()[2..].ToArray();
        Console.WriteLine($"Tail [2..]: {string.Join(", ", tail)}");
    }
}
