namespace Polyfill.Example.IsExternalInit;

internal sealed class Program
{
    private static void Main()
    {
        Console.WriteLine("IsExternalInit polyfill examples (net48)");

        Property p = new() { Name = "Hello" };

        Console.WriteLine($"Name: {p.Name}");
    }
}

file sealed class Property
{
    public string? Name { get; init; }
}
