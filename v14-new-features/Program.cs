// Leverages top-level statements
using System.ComponentModel;
using VehicleSales;

AutoProperties();
NullConditionals();
PartialClasses();

static void AutoProperties()
{
  Console.WriteLine();
  Console.WriteLine("*** Demo: Auto-properties with field");

  Person? person = new Person();
  person?.FirstName = " Rosie ";
  Console.WriteLine($"Trimmed name: *{person?.FirstName}*");
}

static void NullConditionals()
{
  Console.WriteLine();
  Console.WriteLine("*** Demo: Null conditional assignment");

  // Assign a null person
  Person? person = null;

  // This line would throw a NullReferenceException
  // string? firstName = person.LastName;

  // Safe member access with null-conditional operator
  string? firstName = person?.FirstName;

  // But what about this?
  // This will throw a NullReferenceException
  // person.FirstName = "Rosie";

  // v14 null conditional assignment
  person?.FirstName = "Rosie";
  Console.WriteLine($"Null person name: {person?.FirstName ?? "(null)"}");

  // Won't execute setter code
  person?.LastName = "Cotton";

  person?.Address?.City = "Hobbiton";
  Console.WriteLine($"Null address: {person?.Address?.City ?? "(null)"}");

  // Also works with +=/-=
  person?.Age += 1;
  Console.WriteLine($"Null person age: {person?.Age}");

  // But not ++ or --
  // Will throw a compile-time error
  //person?.Age++;

  // Assign a new Person object
  person = new Person();
  person?.FirstName = "Rosie";
  Console.WriteLine($"First Name: {person?.FirstName ?? "(null)"}");

  // Will execute setter code
  person?.LastName = "Cotton";

  // Also works with +=
  person?.Age += 1;
  Console.WriteLine($"Age: {person?.Age}");

}

static void PartialClasses()
{
  Console.WriteLine();
  Console.WriteLine("*** Demo: Partial classes, constructors, methods, and events");

  List<Job> jobs = [
    new Job { Title = "Developer", Department = "IT", Salary = 75000 },
    new Job { Title = "", Department = "Cafeteria", Salary = 30000 },
    new Job { Title = "Software Manager", Department = "", Salary = 150000 },
    new Job { Title = "Sales Rep", Department = "Sales", Salary = -5000 }
  ];

  // Demonstrate partial event
  Job currentJob = new();
  currentJob.PropertyChanged += (sender, e) =>
    Console.WriteLine($"Property: '{e.PropertyName}' changed on Job: '{(sender as Job)?.Title}'");
  currentJob.Title = "Architect";
  currentJob.Department = "IT";
  currentJob.Salary = 120000;

  // Use partial class validation methods
  foreach (var job in jobs)
  {
    Console.Write($"{job.Title}: ");
    if (!job.IsValid(out var errors))
    {
      Console.WriteLine($"{string.Join(", ", errors)}");
    }
    else
    {
      Console.WriteLine("Successfully validated.");
    }
  }
}

public class PersonPreV14
{
  private string? firstName;
  public string? FirstName
  {
    get => firstName;
    set => firstName = value?.Trim();
  }

  public string? LastName { get; set; }
  public Address? Address { get; set; }
}

public class Person
{
  // Auto-property with v14 field keyword
  // Concise expression-bodied syntax
  public string? FirstName { get; set => field = value?.Trim(); }

  // Expanded syntax block to include additional logic
  public string? LastName
  {
    get; set
    {
      field = value?.Trim();
      Console.WriteLine($"Last name changed: {field}");
    }
  }
  public Address? Address { get; set; }
  public int Age { get; set; }
}

public class PersonWithPropertyChanged : INotifyPropertyChanged
{
  public string? FirstName
  {
    get;
    set
    {
      if (field != value)
      {
        field = value?.Trim();
        OnPropertyChanged(nameof(FirstName));
      }
    }
  }
  public string? LastName { get; set; }
  public Address? Address { get; set; }

  public event PropertyChangedEventHandler? PropertyChanged;

  protected virtual void OnPropertyChanged(string propertyName)
  {
    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }
}

public class Address
{
  public string? Street { get; set; }
  public string? City { get; set; }
  public string? State { get; set; }
  public string? ZipCode { get; set; }
}