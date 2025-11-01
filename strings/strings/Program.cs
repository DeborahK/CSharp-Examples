// See https://aka.ms/new-console-template for more information
// Top-level statements -> top-level program
// Ctrl + K Ctrl + ,

// Imagine this is a full-featured application
// We're adding features


// Task 1: Create a message telling the user to say "help"

// string msg = "Please say "help" for assistance"; // Doesn't work

// Quoted string literals (requires escaping special characters)
string msg = "Please say \"help\" for assistance";
Console.WriteLine(msg);

// Verbatim string literals (requires doubling quotes)
string msgVerbatim = @"Please say ""help"" for assistance";
Console.WriteLine(msgVerbatim);

// C# 11
// Raw string literals (triple quotes)
string msgRaw = """Please say "help" for assistance""";
Console.WriteLine(msgRaw);


// Task 2: Create a multiline congratulations message

// Quoted string literals
bool goodCredit = true;
bool newVehicle = true;
if (goodCredit)
{
  if (newVehicle)
  {
    string congrats = "Congratulations on your new vehicle! \n We hope you enjoy driving it!";
    Console.WriteLine(congrats);
  }
}

// Verbatim string literals (for multiline strings)
if (goodCredit)
{
  if (newVehicle)
  {
    string congrats = @"
      Congratulations on your new vehicle!
      We hope you enjoy driving it!";
    Console.WriteLine(congrats);
  }
}

// C# 11
// Raw string literals (triple quotes)
if (goodCredit)
{
  if (newVehicle)
  {
    string congrats = """
      Congratulations on your new vehicle!
      We hope you enjoy driving it!
      """;
    Console.WriteLine(congrats);
  }
}


// Task 3: Create a JSON file with sample data

// Quoted string literals
// DOESN'T WORK!
// string vehicleJSON = "
//   {
//     "id": 1,
//     "name:": "AT-AT",
//     "price": 1999.99
//   }";

// Append the strings (performance issues)
string vehicleJSON = "{ \n \"id\": 1," +
 "\n \"name\": \"AT-AT\","+
 "\n \"price\": 1999.99\n}";
Console.WriteLine(vehicleJSON);

// Verbatim string literals (for multiline strings, requires doubling quotes)
string vehicleJSONVerbatim = @"
  {
    ""id"": 1,
    ""name:"": ""AT-AT"",
    ""price"": 1999.99
  }";
Console.WriteLine(vehicleJSONVerbatim);

// C# 11
// Raw string literals (triple quotes)
Console.WriteLine("Raw string literal");
string vehicleJSONRaw = """
  {
    "id": 1,
    "name": "AT-AT",
    "price": 1999.99
  }
  """;
Console.WriteLine(vehicleJSONRaw);


// Task 4: Use a variable or expression in a string (interpolation)

// Basic string interpolation
string pageTitle = "Vehicle Detail";
string header = $"Header: {pageTitle}";
Console.WriteLine(header);

// C# 10
// Can be a constant
const string pageTitleConst = "Vehicle Detail";
const string headerConst = $"Header: {pageTitleConst}";
Console.WriteLine(headerConst);

// C# 11
// Expression can contain multiple lines
// This uses the ternary conditional operator
string pageTitleMulti = "Vehicle Detail";
string headerMulti = $"Header: {
      (pageTitleMulti == ""
        ? "No title"
        : pageTitleMulti)
    }";
Console.WriteLine(headerMulti);


// Task 5: Use a variable or expression in a JSON string (interpolation)

string vehicleName = "AT-AT";
decimal price = 1999.99m;

// Verbatim string interpolation (double the curly braces and quotes)
// Allows multiple lines of text and interpolation
string vehicleJSONInterpolation = $@"
  {{
    ""id"": 1,
    ""name:"": ""{vehicleName}"",
    ""price"": {price}
  }}";
Console.WriteLine(vehicleJSONInterpolation);

// C# 11
// Raw string interpolation (triple quotes)
// Allows multiple lines of text and interpolation
// Use double dollars and double curly braces for the replacement string
string vehicleJSONInterpolationRaw = $$"""
{
  "id": 1,
  "name:": "{{vehicleName}}",
  "price": {{price}}
}
""";
Console.WriteLine(vehicleJSONInterpolationRaw);

// Extensible!
// Three dollar signs!
string extensibleheader = $$$"""
      <div class="card">
        {{vehicleName}}
      </div>
    """;
Console.WriteLine("Extensible header:");
Console.WriteLine(extensibleheader);

// Task 6: Display different text based on the quantity (Switch statement -> Switch expression)

int? quantity = 16;

// Switch statement
string itemTextStmt = "";
switch (quantity)
{
  case 0:
    itemTextStmt = "No items";
    break;
  case 1:
    itemTextStmt = "One item";
    break;
  default:
    itemTextStmt = $"{quantity} items";
    break;
}
Console.WriteLine(itemTextStmt);

// C# 8
// Switch expression
// Shorter syntax, assigned to a variable
// Uses pattern matching
// Compiler ensures all cases are covered
// Discard operator (underscore) is the "catch all"
string itemText = quantity switch
{
  0 => "No items",
  1 => "One item",
  _ => $"{quantity} items"
};
Console.WriteLine(itemText);

// C# 8
// Order is important
// Pattern is unreachable error
// string itemText = quantity switch
// {
//   0 => "No items",
//   1 => "One item",
//   _ => $"{quantity} items",
//   2 => "Two items"
// };
// Console.WriteLine(itemText);

// C# 9
// Relational pattern
// Uses relational operators to test the value
string itemTextRelational = quantity switch
{
  <= 0 => "No items",
  1 => "One item",
  >= 2 => $"{quantity} items",
};
Console.WriteLine(itemTextRelational);

// C# 9
// Logical pattern
// Combine or negate with and, or, not
string itemTextLogical = quantity switch
{
  0 => "No items",
  1 => "One item",
  >= 2 and < 12 => $"{quantity} items",
  < 20 and not 12 => "Not 12 items",
  _ => "Too many items"
};
Console.WriteLine(itemTextLogical);

// C# 8
// Variable (or var) pattern
// Declare a variable using var
// Useful when the switch is an expression
int CountItems() {
  return 18;
}
string itemTextVar = CountItems() switch
{
  0 => "No items",
  1 => "One item",
  var q => $"{q} items"
};
Console.WriteLine(itemTextVar);

// C# 8
// Variable (or var) pattern with when (case guard)
// Declare a variable using var
// Notice the when syntax, it must be a boolean expression
string itemTextGuard = CountItems() switch
{
  0 => "No items",
  1 => "One item",
  var q when q >= 2 && q < 12 => $"{q} items",
  < 20 and not 12 => "Not 12 items",
  _ => "Too many items"
};
Console.WriteLine(itemTextGuard);

// C# 8
// Case guard (when)
// Guard must be a boolean expression
// Great for complex conditionals
// Recall that order matters!
bool inStock = true;
bool creditApproved = true;
string itemTextGuards = CountItems() switch
{
  <= 0 => "No items",
  _ when !inStock => "Out of stock",
  1 => "One item",
  var q when creditApproved => $"{q} items",
  _ => "Credit not approved for more than 1 item"
};
Console.WriteLine(itemTextGuards);


// Task 7: Display different text based on the quantity with tuple pattern

// C# 8
// Tuple pattern
// Switch on a set of values defined with a tuple
string itemTextTuple = (quantity, inStock, creditApproved) switch
{
  (<= 0 or null, _, _) => "No items",
  (_, false, _) => "Out of stock",
  (1, true, _) => "One item",
  (_, true, true) => $"{quantity} approved items",
  _ => "Credit not approved for more than 1 item"
};
Console.WriteLine(itemTextTuple);


// Task 8: Display different text based on the quantity with type pattern

// C# 9
// Type pattern
// Switch on the type
// Useful with generics
// Correctly types the switched value (info)
string PrepareMessage<T>(IEnumerable<T> info)
{
  string message = info switch
  {
    null => "Value is null",
    List<int> list => $"List has {list.Count} integer items",
    List<string> list => string.Join(", ", list),
    _ => "Value is not a list of integers or strings"
  };
  return message;
}
Console.WriteLine(PrepareMessage(new List<int>() { 1, 2, 3 }));
Console.WriteLine(PrepareMessage(new List<string>() { "a", "b", "c" }));
Console.WriteLine(PrepareMessage(new List<decimal>() { 1.2m, 3.5m, 8.8m }));


// Task 9: Check elements with the list pattern

// C# 11
// List pattern
// _ => discard: match one
// .. => slice: match 0 or more (can only be used once)
int[] item = { 1,2,3,4,5};
string itemTextList = item switch
{
  [1,_,3,..] => "Has 1, 3, and more",
  [..,4,_] => "Contains a 4",
  [..,5] => "Ends with a 5",
  _ => "Something else"
};
Console.WriteLine(itemTextList);
