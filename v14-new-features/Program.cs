// Leverages top-level statements
using System.ComponentModel;

AutoProperties();
NullConditionals();

static void AutoProperties()
{
  Person? person = new Person();
  person?.FirstName = " Rosie ";
  Console.WriteLine($"Trimmed name: *{person?.FirstName}*");
}

static void NullConditionals()
{
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
  // Outputs "Null person: (null)"
  Console.WriteLine($"Null person: {person?.FirstName ?? "(null)"}");

  person?.Address?.City = "Hobbiton";
  Console.WriteLine($"Null address: {person?.Address?.City ?? "(null)"}");

  // Assign a new Person object
  person = new Person();
  person?.FirstName = "Rosie";
  // Outputs "New person: Rosie"
  Console.WriteLine($"New person: {person?.FirstName ?? "(null)"}");
}

class Person
{
  // Auto-property with v14 field keyword
  public string? FirstName { get; set => field = value?.Trim(); }
  public string? LastName { get; set; }
  public Address? Address { get; set; }
}

class PersonPreV14
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

class PersonWithPropertyChanged : INotifyPropertyChanged
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

class Address
{
  public string? Street { get; set; }
  public string? City { get; set; }
  public string? State { get; set; }
  public string? ZipCode { get; set; }
}