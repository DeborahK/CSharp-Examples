// Leverages top-level statements
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
  // person?.Age++;

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

  // Demonstrate parameterized partial constructor
  Job currentJob = new("Developer", "IT", 75000);
  Console.WriteLine($"Current Job Title: {currentJob.Title}, Department: {currentJob.Department}, Salary: {currentJob.Salary}");

  // Demonstrate partial event
  PropertyChangedEventHandler handler = (sender, e) =>
    Console.WriteLine($"Property: '{e.PropertyName}' changed on Job: '{(sender as Job)?.Title}'");
  currentJob.PropertyChanged += handler;

  currentJob.Title = "Architect";
  currentJob.Salary = 120000;
  Console.WriteLine($"New Job Title: {currentJob.Title}, Department: {currentJob.Department}, Salary: {currentJob.Salary}");
  Console.WriteLine($"MaxVacationDays: {currentJob.MaxVacationDays}");
  Console.WriteLine($"IsOnCommission: {currentJob.isOnCommission}");

  // Unsubscribe
  currentJob.PropertyChanged -= handler;

  // Demonstrate parameterless partial constructor
  Job emptyJob = new();
  Console.WriteLine($"Empty Job Title: {emptyJob.Title}, Department: {emptyJob.Department}, Salary: {emptyJob.Salary}");

}

// Pre-v14 implementation without field keyword
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

// v14 implementation with field keyword
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