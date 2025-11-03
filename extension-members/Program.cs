// Leverages top-level statements
using System.Numerics;

ExtensionMembers();

static void ExtensionMembers()
{
  // C# 3, .NET 3.5 (November 2007)
  string title = "Lord of the Rings: Return of the King.";
  Console.WriteLine($"Original message: {title}");

  // Use the extension method to truncate the string
  string truncatedMessage_v3 = title.Truncate_V3(17);
  Console.WriteLine($"Truncated message with v3: {truncatedMessage_v3}");

  // C#14, .NET 10 (November 2025)
  string truncatedMessage_v14 = title.Truncate(17);
  Console.WriteLine($"Truncated message with v14: {truncatedMessage_v14}");
  Console.WriteLine($"Word count: {title.WordCount}");

  // --------------------------//

  // Collection initializer syntax (C# 9, .NET 5 or later)
  Console.WriteLine("------ Creating lists ------");
  List<string> hobbits = ["Frodo", "Sam", "Bilbo"];
  List<string> humans = ["Boromir", "Faramir"];
  Console.WriteLine($"Hobbits: {string.Join(", ", hobbits)}");

  // Use the instance extension method to add an item if it doesn't exist
  Console.WriteLine("------ Adding more hobbits ------");
  hobbits.AddIfNotExists("Merry");
  hobbits.AddIfNotExists("Frodo"); // Duplicate, won't be added

  // Fluent chaining
  if (hobbits.AddIfNotExists("Pippin")) Console.WriteLine("Added Pippin");

  Console.WriteLine($"Updated hobbits: {string.Join(", ", hobbits)}");

  // Use the instance extension property to retrieve the last item or null
  string? lastHobbit = hobbits.LastOrNull;
  Console.WriteLine($"Last hobbit: {lastHobbit}");

  // Use the static extension operator to concatenate the lists
  List<string> all = hobbits + humans;
  Console.WriteLine($"All names: {string.Join(", ", all)}");

  // Use the static extension property to get an empty list
  // Then check if it's empty using the instance extension property
  Console.WriteLine("------ Creating an empty list ------ ");
  List<string> empty = List<string>.EmptyList;
  Console.WriteLine($"Is empty? {empty.IsEmpty}");
  Console.WriteLine($"Last item: {empty.LastOrNull ?? "(null)"}");

  // Use the generic math extension method to generate a range of numbers
  // Extension method does not appear on string
  Console.WriteLine("------ Generating a range of numbers ------");
  var numbers = int.Range(12,6);
  Console.WriteLine(string.Join(", ", numbers));
}

// C# 3, .NET 3.5 (November 2007)
public static class StringExtensions_V3
{
  public static string Truncate_V3(this string value, int maxLength)
      => value.Length <= maxLength ? value : value[..maxLength];

  // Can't have properties or static members with C# 3 extension methods
}

// C#14, .NET 9 (November 2025)
public static class CustomExtensions
{
  // Extension declaration for strings
  extension(string value)
  {
    // Instance extension method
    public string Truncate(int maxLength)
      => value.Length <= maxLength ? value : value[..maxLength];

    // Instance extension property
    public int WordCount
      => string.IsNullOrWhiteSpace(value) ? 0
        : value.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
  }

  // Extension declaration for List<T>
  extension<T>(List<T> list)
  {
    // Instance extension property
    public bool IsEmpty => list.Count == 0;
    // Uses index from end operator (C# 8.0 and later)
    public T? LastOrNull => list.Count == 0 ? default : list[^1];

    // Instance extension method
    public bool AddIfNotExists(T item)
    {
      if (list.Contains(item)) return false;
      list.Add(item);
      return true;
    }

    // Static extension property
    public static List<T> EmptyList => [];

    // Static extension operator
    public static List<T> operator +(List<T> first, List<T> second)
          => first.Concat(second).ToList();
  }

  // Extension declaration with constraint
  // Expose factory methods in places that make sense
  // C# 11 generic math support
  extension<T>(T source) where T : INumber<T>
  {
    public static IEnumerable<T> Range(T start, int count)
    {
      // Lazy evaluation
      for (int i = 0; i < count; i++) yield return start++;
    }
  }

}
