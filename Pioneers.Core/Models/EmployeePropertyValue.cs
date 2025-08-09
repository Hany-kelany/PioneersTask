namespace Pioneers.Core.Models;

public class EmployeePropertyValue
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public Employee Employee { get; set; }

    public int CustomPropertyId { get; set; }

    public CustomProperty EmployeeProperty { get; set; }

    public string Value { get; set; }
}