global using System.Diagnostics.CodeAnalysis;

// Leverages top-level statements
StringFeatures();
StringInterpolation();
StringIndentation();
SwitchAndPatterns();
PropertyFeatures();
RecordFeatures();

static void StringFeatures()
{
  // Basic string
  string header0 = "<div class=\"card\"><div class=\"card-header\">Vehicle Detail</div></div>";
  Console.WriteLine($"Basic:\n {header0}");

  // Verbatim string literal
  string header1 = @"
      <div class=""card"">
        <div class=""card-header"">
          Vehicle Detail
        </div>
      </div>
    ";
  Console.WriteLine($"Verbatim:\n {header1}");

  // Raw string literal
  string header2 = """
      <div class="card">
        <div class="card-header">
          Vehicle Detail
        </div>
      </div>
    """;
  Console.WriteLine($"Raw:\n {header2}");

  string text = """He said, "None shall Pass".""";
  Console.WriteLine(text);

  string vehicleJSON = """
      { 
        "id": 1, 
        "name": "AT-AT", 
        "price": 19416.13 
      }
      """;
  Console.WriteLine(vehicleJSON);
}

static void StringInterpolation()
{

  // Basic Interpolated string
  string pageTitle = "Vehicle Detail";

  string header3 = $"Header: {pageTitle}";
  Console.WriteLine($"Interpolated:\n {header3}");

  // Additional examples
  string answer = $"Answer: {20 * 2 + 2}";
  Console.WriteLine($"Interpolated answer:\n {answer}");

  string header31 = $"Header: {pageTitle.ToUpper()}";
  Console.WriteLine($"Interpolated ToUpper:\n {header31}");

  var PrepareTitle = new Func<string, string>(message => $"<h1>{message}</h1>");
  string header32 = $"Header: {PrepareTitle(pageTitle)}";
  Console.WriteLine($"Interpolated function call:\n {header32}");

  // Constant interpolated string
  const string pageTitle4 = "Vehicle Detail";
  const string header4 = $"Header: {pageTitle4}";
  Console.WriteLine($"Constant interpolated:\n {header4}");

  // Newlines in interpolated string expressions
  string pageTitle5 = "";
  string header5 = $"Header: {(string.IsNullOrWhiteSpace(pageTitle5)
      ? "No title"
      : pageTitle5)}";
  Console.WriteLine($"Interpolated with newline:\n {header5}");

  // If statement in interpolated string expression
  string header51 = $"Header:{() =>
    {
      if (string.IsNullOrWhiteSpace(pageTitle5))
      {
        return "No title";
      }
      else
      {
        return pageTitle5;
      }
    }}";

  // Verbatim interpolated string
  string header6 = @$"
      <div class=""card"">
        <div class=""card-header"">
          {pageTitle}
        </div>
      </div>
    ";
  Console.WriteLine($"Verbatim Interpolated:\n {header6}");

  string header6a = @$"
      <div class=""card"">
        <div class=""card-header"">
          {(pageTitle == ""
           ? "No title"
           : pageTitle)}
        </div>
      </div>
    ";
  Console.WriteLine($"Verbatim Multiline Interpolated:\n {header6a}");

  // Raw interpolated string
  string header7 = $"""
      <div class="card">
        <div class="card-header">
          {pageTitle}
        </div>
      </div>
    """;
  Console.WriteLine($"Raw Interpolated:\n {header7}");

  string header7a = $"""
      <div class="card">
        <div class="card-header">
          {(pageTitle == ""
           ? "No title"
           : pageTitle)}
        </div>
      </div>
    """;
  Console.WriteLine($"Raw Multiline Interpolated:\n {header7a}");

  decimal price = 19416.13M;
  string vehicleJSON2 = $$"""
      {
        "id": 1,
        "name": "AT-AT",
        "price": {{price}}
      }
      """;
  Console.WriteLine($"Raw Interpolated:\n {vehicleJSON2}");

  decimal price3 = 9416.13M;
  string vehicleJSON3 = $$"""
      {
        "id": 1,
        "name": "AT-AT",
        "price": {{price3}},
        "priceNote": {{(price3 < 10000
          ? """ "value menu" """
          : """ "" """)}}
      }
      """;
  Console.WriteLine($"Raw Interpolated JSON:\n {vehicleJSON3}");
}

static void StringIndentation()
{
  var goodCredit = true;
  var newVehicle = true;
  var vehicles = new Vehicle[] {
    new Vehicle {
      Id = 1,
      Name = "Model X Plaid",
      Price = 120_000,
      Passengers = 6,
      ZeroTo60 = 2.7M
    },
    new Vehicle {
      Id = 1,
      Name = "Model X Plaid",
      Price = 120_000,
      Passengers = 6,
      ZeroTo60 = 2.7M
    }
  };

  var message = "";

  foreach (var vehicle in vehicles)
  {
    if (goodCredit)
    {
      if (newVehicle)
      {
        //         message = @"
        // Congratulations on your new vehicle!
        // We hope you enjoy driving it as much as we enjoyed building it.
        // ";
        //       }
        message = """
          Congratulations on your new vehicle!
          We hope you enjoy driving it as much as we enjoyed building it.
          """;
      }
      else
      {
        message = @"
          Congratulations on your fully refurbished vehicle!
          Contact us for extended warranty information.
          ";
      }
    }
    else
    {
      message = @"
        We regret to inform you that we cannot approve your credit application.
        Please contact us for more information.
        ";
    }
  }
  Console.WriteLine($"Indented message: {message}");
}

static void SwitchAndPatterns()
{
  // Basic switch statement
  int quantity0 = 5;
  string itemText0 = "";
  switch (quantity0)
  {
    case 0:
      itemText0 = "No items";
      break;
    case 1:
      itemText0 = "One item";
      break;
    default:
      itemText0 = $"{quantity0} items";
      break;
  }
  Console.WriteLine($"Basic switch statement: {itemText0}");

  // Basic switch expression
  int? quantity2 = null;
  const int singleItem = 1;
  string itemText2 = quantity2 switch
  {
    0 => "No items",
    singleItem => "One item",
    null => "Not specified",
    _ => $"{quantity2} items"
  };
  Console.WriteLine($"Basic switch expression: {itemText2}");

  // Simple Boolean example
  bool isItemInStock = true;
  string itemText3 = isItemInStock switch
  {
    true => "Item is in stock",
    false => "Item is not in stock",
  };
  Console.WriteLine($"Simple example: {itemText3}");

  int? quantity4 = 4;
  string itemText4 = quantity4 switch
  {
    0 => "No items",
    1 => "One item",
    null => "Not specified",
    _ => $"{quantity4} items"
  };
  Console.WriteLine($"Discard pattern: {itemText4}");

  string itemText5 = CountItems() switch
  {
    0 => "No items",
    1 => "One item",
    null => "Not specified",
    var q5 => $"{q5} items"
  };
  Console.WriteLine($"Variable pattern: {itemText5}");

  int? CountItems() => 8;

  // var pattern or variable pattern
  string itemText51 = GetName() switch
  {
    "" or null => "No match",
    "Spade" => "Too old",
    "Sparrow" => "Wrong movie",
    var n when n == "Harkness" => $"{n} is right",
    _ => "No match"
  };
  Console.WriteLine($"Variable pattern: {itemText51}");

  bool inStock = true;
  bool creditApproved = true;
  string itemText6 = CountItems() switch
  {
    0 => "No items",
    null => "Not specified",
    _ when !inStock => "Out of stock",
    1 => "One item",
    var q6 when creditApproved => $"{q6} items",
    _ => "Not enough credit"
  };
  Console.WriteLine($"When statement: {itemText6}");

  int? quantity7 = 2;
  string itemText7 = quantity7 switch
  {
    <= 0 => "No items",
    1 => "One item",
    >= 2 => $"{quantity7} items",
    null => "Not specified"
  };
  Console.WriteLine($"Relational pattern: {itemText7}");

  int? quantity8 = 18;
  string itemText8 = quantity8 switch
  {
    0 or null => "No items",
    1 => "One item",
    >= 2 and < 12 => $"{quantity8} items",
    < 20 and not 12 => "Not 12 items",
    _ => "Too many items"
  };
  Console.WriteLine($"Combine or negate: {itemText8}");

  int? quantity9 = 12;
  bool isInStock9 = true;
  string itemText9 = (quantity9, isInStock9) switch
  {
    (0 or null, _) => "No items",
    (1, true) => "One item",
    ( >= 2 and < 12, true) => $"{quantity9} items",
    (_, true) => "Too many items",
    (_, false) => "Out of stock"
  };
  Console.WriteLine($"Tuple patterns: {itemText9}");

  // Declaration pattern
  int? quantity3 = 12;
  if (quantity3 is int q)
  {
    Console.WriteLine($"Declaration pattern: {q}");
  }
  else
  {
    Console.WriteLine($"Declaration pattern: Value is null");
  }

  // Type Pattern
  var items1 = new List<int> { 1, 2, 3, 4, 5 };
  Console.WriteLine($"Type pattern: {PrepareMessage(items1)}");
  var items2 = new List<string> { "h", "o", "b", "b", "i", "t" };
  Console.WriteLine($"Type pattern: {PrepareMessage(items2)}");
  var items3 = new[] { "h", "o", "b", "b", "i", "t" };
  Console.WriteLine($"Type pattern: {PrepareMessage(items3)}");
  var items4 = new List<double> { 1.1, 7.3, 5.5 };
  Console.WriteLine($"Type pattern: {PrepareMessage(items4)}");

  // Property pattern
  Vehicle vehicle = new Vehicle
  {
    Id = 1,
    Name = "Model X Plaid",
    ZeroTo60 = 2.7M,
    Passengers = 6
  };
  decimal price = vehicle switch
  {
    { ZeroTo60: < 3, Passengers: 7 } => 120_000,
    { ZeroTo60: < 3, Passengers: 6 } => 110_000,
    { ZeroTo60: < 4, Passengers: 7 } => 105_000,
    { ZeroTo60: < 4, Passengers: 6 } => 99_990,
    _ => 90_000
  };
  Console.WriteLine($"Property pattern: {price}");

  // List Pattern
  int[] item = { 1, 2, 3, 4, 5 };
  if (item is [1, _, 3, ..])
  {
    Console.WriteLine("List Pattern: Item has 1, 3, and more elements");
  }
  if (item is [.., 5])
  {
    Console.WriteLine("List Pattern: Item ends with 5");
  }

  // Credit card transactions
  string[] transactions = { "1, PURCHASE, 400", "2, PAYMENT, 50", "3, PURCHASE, 40.57" };
  decimal balance = 0.0M;
  foreach (var transaction in transactions)
  {
    string[] row = transaction.Split(',', StringSplitOptions.TrimEntries);
    balance += row switch
    {
      [_, "PAYMENT", var amount] => -decimal.Parse(amount),
      [_, "PURCHASE", var amount] => decimal.Parse(amount),
      _ => 0.0M
    };
  }
  Console.WriteLine($"Balance: {balance}");
}

static void PropertyFeatures()
{
  // Use default constructor
  var vehicle1 = new Vehicle
  {
    Id = 1,
    Name = "Model X Plaid",
    ZeroTo60 = 2.7M,
    Passengers = 6
  };
  Console.WriteLine($"Vehicle: {vehicle1.Id}, {vehicle1.Name}, {vehicle1.ZeroTo60}, {vehicle1.Passengers}");

  // Use init-only constructor
  var vehicle2 = new Vehicle(2)
  {
    Name = "Model Y",
    ZeroTo60 = 3.5M,
    Passengers = 5
  };
  Console.WriteLine($"Vehicle: {vehicle2.Id}, {vehicle2.Name}, {vehicle2.ZeroTo60}, {vehicle2.Passengers}");
}

static void RecordFeatures()
{
  // Create and populate an object
  var vehicle1 = new Vehicle
  {
    Id = 1,
    Name = "Model X Plaid",
    Price = 120_000,
    Passengers = 6,
    ZeroTo60 = 2.7M
  };

  var vehicle1a = new Vehicle
  {
    Id = 1,
    Name = "Model X Plaid",
    Price = 120_000,
    Passengers = 6,
    ZeroTo60 = 2.7M
  };
  Console.WriteLine($"Vehicle1 == Vehicle1a: {vehicle1 == vehicle1a}"); // false
  // Display class details
  Console.WriteLine(vehicle1); // Vehicle

  // Create and populate a record
  var vehicle2 = new VehicleData(2, "Model Y", 99_990M, 5, 3.5M);
  var vehicle2a = new VehicleData(2, "Model Y", 99_990M, 5, 3.5M);
  Console.WriteLine($"Vehicle2 == Vehicle2a: {vehicle2 == vehicle2a}"); // true
  // Display record details
  Console.WriteLine(vehicle2); // Vehicle { ... }

  // Record, deconstruct, and positional pattern matching
  var bestFor = vehicle2 switch
  {
    (_, "Model Y", _, _, _) => "Best for small family",
    (_, "Model X", _, _, _) => "Best for large family",
    (_, "Model X Plaid", _, _, _) => "Best for performance",
    _ => "Best for price"
  };

  // Using the var keyword, C# infers the type of the variables
  var (id, name, price, passengers, zeroTo60) = vehicle2;
  var bestFor2 = name switch
  {
    "Model Y" => "Best for small family",
    "Model X" => "Best for large family",
    "Model X Plaid" => "Best for performance",
    _ => "Best for price"
  };

  var bestFor3 = vehicle2.Name switch
  {
    "Model Y" => "Best for small family",
    "Model X" => "Best for large family",
    "Model X Plaid" => "Best for performance",
    _ => "Best for price"
  };

  // Nondestructive mutation
  var vehicle3 = vehicle2 with { Passengers = 6 };
}

static string PrepareMessage<T>(IEnumerable<T> info)
{
  string message = info switch
  {
    null => "Value is null",
    List<int> list => $"List has {list.Count} items",
    List<string> list => string.Join(", ", list),
    _ => "Value is not a list of integers or a string"
  };
  return message;
}

static string GetName()
{
  return "Harkness";
}

public class Order
{
  public string? Rep { get; set; }
  public decimal? Price { get; set; }
  public int? Quantity { get; set; }
  public decimal? Total => Price * Quantity;

  public Order() : this("None", 1) { }
  public Order(string rep, int quantity) =>
    (Rep, Quantity) = (rep, quantity);
}

public class Vehicle
{
  public required int Id { get; init; }
  // Expression bodied members
  private string? name = string.Empty;
  public string? Name
  {
    get => name.ToUpper();
    set => name = value;
  }
  public decimal? Price { get; set; }

  public int Passengers { get; set; } = 5;
  public decimal ZeroTo60 { get; set; }

  public Vehicle() { }
  [SetsRequiredMembers]
  public Vehicle(int id) => Id = id;

  public decimal CalculateMilesPerCharge()
  {
    return 0;
  }
  public decimal CalculateNextPayment()
  {
    return 0;
  }
}

// Record using positional notation
public record VehicleData(int Id, string Name, decimal Price, int Passengers, decimal ZeroTo60);

// Record using property notation
public record VehicleData2
{
  public int Id { get; init; }
  public string Name { get; init; } = "";
  public decimal Price { get; init; }
  public int Passengers { get; init; }
  public decimal ZeroTo60 { get; init; }
}


