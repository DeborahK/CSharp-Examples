#nullable enable
using System.ComponentModel;

namespace VehicleSales;

// Manual implementation part of the partial class
public partial class Job
{
  // Declaration of the partial event
  public partial event PropertyChangedEventHandler? PropertyChanged;

  // Implementation of the partial constructor
  public partial Job() : this("Untitled", "Unassigned", 0m) { }
  public partial Job(string title, string department, decimal salary)
  {
    Title = title;
    Department = department;
    Salary = salary;
  }

  // Implementation of the partial method
  public partial void CalculateMaxVacationDays()
  {
    MaxVacationDays = Department switch
    {
      "Sales" => 20,
      "IT" => 21,
      _ => 14
    };
  }
}
