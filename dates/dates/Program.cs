// See https://aka.ms/new-console-template for more information

// Task 1: Track a date without a time

// DateTime
DateTime hireDateTimeType = new DateTime(2024, 3, 14);
Console.WriteLine(hireDateTimeType);

// C# 9
// Target-typed new expression
DateTime hireDateTime = new(2024, 3, 14);
Console.WriteLine(hireDateTime);

// .NET 6
// DateOnly
DateOnly hireDate = new(2024, 3, 14);
Console.WriteLine(hireDate);

// Get the current date as date only
DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
Console.WriteLine(currentDate);

// Find the number of days between two dates
int numDays = currentDate.DayNumber - hireDate.DayNumber;
Console.WriteLine($"Days employed: {numDays}");


// Task 2: Track a time without a date

// TimeSpan
TimeSpan alarmTimeSpan = new(7, 0, 0);
Console.WriteLine(alarmTimeSpan);

// .NET 6
// TimeOnly
TimeOnly alarmTime = new(7, 0, 0);
Console.WriteLine(alarmTime);

// Current time
TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
Console.WriteLine(currentTime);

// Find the amount of time between two times
TimeSpan numHoursSince = currentTime - alarmTime;
Console.WriteLine($"Hours since alarm: {numHoursSince.TotalHours:N0}");

TimeSpan numHoursUntil = alarmTime - currentTime;
Console.WriteLine($"Hours before the next alarm: {numHoursUntil.TotalHours:N0}");

// Determine if a store is open
TimeOnly open = new(10,0,0);
TimeOnly close = new(18,0,0);

if (currentTime.IsBetween(open, close))
  Console.WriteLine("It's open!");
else
  Console.WriteLine("It's closed");