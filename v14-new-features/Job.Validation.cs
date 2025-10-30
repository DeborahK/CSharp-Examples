namespace VehicleSales;

partial class Job
{
    public bool IsValid(out List<string> errors)
    {
        errors = new List<string>();

        if (string.IsNullOrWhiteSpace(Title))
        {
            errors.Add("Title is required.");
        }

        if (string.IsNullOrWhiteSpace(Department))
        {
            errors.Add("Department is required.");
        }

        if (Salary.HasValue && Salary.Value < 0)
        {
            errors.Add("Salary cannot be negative.");
        }

        return errors.Count == 0;
    }

    public bool IsValid() => IsValid(out _);

    public void Validate()
    {
        if (!IsValid(out var errors))
        {
            throw new InvalidOperationException(
                $"Job validation failed: {string.Join(", ", errors)}");
        }
    }
}
