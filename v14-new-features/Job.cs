namespace VehicleSales;

// Manual implementation part of the partial class
public partial class Job
{
  // Implementation of the partial constructor
  public partial Job() : this("Untitled", "Unassigned", 0m) { }
  public partial Job(string title, string department, decimal salary)
  {
    Title = title;
    Department = department;
    Salary = salary;
  }

  // Implementation of the partial method
  partial void CalculateMaxVacationDays()
  {
    MaxVacationDays = Department switch
    {
      "Sales" => 20,
      "IT" => 21,
      _ => 14
    };
  }

  // Implementation of the partial event
  private PropertyChangedEventHandler? _propertyChanged;
  public partial event PropertyChangedEventHandler? PropertyChanged
  {
    add { _propertyChanged += value; }
    remove { _propertyChanged -= value; }
  }

  // The raiser
  protected void OnPropertyChanged(string propertyName) =>
      _propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

}
