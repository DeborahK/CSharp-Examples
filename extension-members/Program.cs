// Leverages top-level statements
ExtensionMembers();

static void ExtensionMembers()
{
  // C# 3, .NET 3.5 (November 2007)
  string title = "Lord of the Rings: Return of the King.";
  Console.WriteLine($"Original message: {title}");

  // Use the extension method to truncate the string
  string truncatedMessage_v3 = title.Truncate_V3(17);
  Console.WriteLine($"Truncated message with v3: {truncatedMessage_v3}");

  // C#14, .NET 9 (November 2025)
  string truncatedMessage_v14 = title.Truncate_V14(17);
  Console.WriteLine($"Truncated message with v14: {truncatedMessage_v14}");
  Console.WriteLine($"Word count: {title.WordCount_V14}");

  // --------------------------//

  // Collection initializer syntax (C# 9, .NET 5 or later)
  Console.WriteLine("------ Creating lists ------");
  List<string> hobbitNames = ["Frodo", "Sam", "Bilbo"];
  List<string> humanNames = ["Boromir", "Faramir"];
  Console.WriteLine($"List of Hobbits: {string.Join(", ", hobbitNames)}");

  // Use the instance extension method to add an item if it doesn't exist
  Console.WriteLine("------ Adding Merry and Frodo ------");
  hobbitNames.AddIfNotExists("Merry");
  hobbitNames.AddIfNotExists("Frodo"); // Duplicate, won't be added
  Console.WriteLine($"Updated list of Hobbits: {string.Join(", ", hobbitNames)}");

  // Use the instance extension property to retrieve the last item or null
  string? lastHobbit = hobbitNames.LastOrNull;
  Console.WriteLine($"Last hobbit in the list: {lastHobbit}");

  // Use the static extension operator to concatenate the lists
  List<string> allNames = hobbitNames + humanNames;
  Console.WriteLine($"All names: {string.Join(", ", allNames)}");

  // Use the static extension property to get an empty list
  // Then check if it's empty using the instance extension property
  Console.WriteLine("Creating an empty list...");
  List<string> emptyList = List<string>.Empty;
  Console.WriteLine($"Is this list empty? {emptyList.IsEmpty}");
  string? lastItem = emptyList.LastOrNull;
  Console.WriteLine($"Last item in the list: {lastItem}");
}

// C# 3, .NET 3.5 (November 2007)
public static class StringExtensions_V3
{
  public static string Truncate_V3(this string value, int maxLength)
      => value.Length <= maxLength ? value : value[..maxLength];

  // Can't have properties or static members with C# 3 extension methods
}

// C#14, .NET 9 (November 2025)
public static class StringExtensions_V14
{
  // Extension declaration for strings
  // Uses expression-bodied members
  extension(string value)
  {
    public string Truncate_V14(int maxLength)
      => value.Length <= maxLength ? value : value[..maxLength];

    public int WordCount_V14
      => string.IsNullOrWhiteSpace(value) ? 0
        : value.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
  }
}

// Extension declaration for strings
// Using normal properties and methods (not expression-bodied members)
public static class CustomExtensions
{
  // Extension declaration for strings
  extension(string value)
  {
    public string Truncate(int maxLength)
    {
      return value.Length <= maxLength ? value : value[..maxLength];
    }

    public int WordCount
    {
      get
      {
        return string.IsNullOrWhiteSpace(value) ? 0
              : value.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
      }
    }
  }

  // Extension declaration for List<T>
  extension<T>(List<T> list)
  {
    // Instance extension properties
    public bool IsEmpty => list.Count == 0;
    // Uses index from end operator (C# 8.0 and later)
    public T? LastOrNull => list.Count == 0 ? default : list[^1];

    // Instance extension method
    public void AddIfNotExists(T item)
    {
      if (!list.Contains(item))
        list.Add(item);
    }

    // Static extension property
    public static List<T> Empty => [];

    // Static extension operator
    public static List<T> operator +(List<T> first, List<T> second)
          => first.Concat(second).ToList();
  }
}
