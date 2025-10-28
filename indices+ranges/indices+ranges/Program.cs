// See https://aka.ms/new-console-template for more information


// Task 1: Pull items from the end of an array

string[] cast0 = new string[] { "Frodo", "Bilbo", "Gandalf", "Aragorn", "Arwen", "Eowyn"};
// New C# 12 collection expression
string[] cast = ["Frodo", "Bilbo", "Gandalf", "Aragorn", "Arwen", "Eowyn"];
string[] extendedCast = [.. cast, "Legolas"];

Console.WriteLine(String.Join(", ", cast0));
Console.WriteLine(String.Join(", ", cast));
Console.WriteLine(String.Join(", ", extendedCast));

// Original technique
string lastPersonOrg = cast[cast.Length - 1];
Console.WriteLine(lastPersonOrg);

// C# 8
// Use the "index from end" operator (^)
// Accesses items from the end
string lastPerson = cast[^1];
Console.WriteLine(lastPerson);

string nextToLastPerson = cast[^2];
Console.WriteLine(nextToLastPerson);

// Available for any type that is "countable"
// That is, has a Length or Count property

string text = "This is some text!";
Index bang = ^1;                        // Define it in a variable (optional)
Console.WriteLine(text[bang]);          // Last character
Console.WriteLine(text[^text.Length]);  // First character

//List<string> items = new() { "ring", "sword", "bow", "axe" };
// New C# 12 collection expression
List<string> items = ["ring", "sword", "bow", "axe"];
Console.WriteLine(items[^1]);  // Last item
Console.WriteLine(items[^2]);  // Second to last item


// Task 2: Pull a subset of items from an array

// C# 8
// Use the range operator (..)
// Creates a subset
// Left operand is inclusive start of the range
// Right operator is exclusive end of the range
string[] hobbitCast = cast[1..4];
Console.WriteLine(String.Join(", ", hobbitCast));

// Can use the index from end operator (^)
string[] notHobbits = cast[2..^0];
Console.WriteLine(String.Join(", ", notHobbits));

// Or leave it open ended
string[] hobbits = cast[..2];
Console.WriteLine(String.Join(", ", hobbits));

// Works with string
// Does NOT work with List<T>
string someText = "This is some text!";
Range some = 8..12;                 // Define it in a variable
Console.WriteLine(someText[some]);  // Just some
Console.WriteLine(someText[..4]);   // First word

// Task 3: Pass a range to a method
void displayStats(int[] sequence, Range range)
{
  Console.WriteLine($"Min: {sequence[range].Min()}");
  Console.WriteLine($"Max: {sequence[range].Max()}");
  Console.WriteLine($"Ave: {sequence[range].Average()}");
}
displayStats(new int[] { 10, 20, 30, 40, 50 }, 2..4);
displayStats(new int[] { 10, 20, 30, 40, 50 }, 1..^1);
