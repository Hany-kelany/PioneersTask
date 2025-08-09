using System.ComponentModel.DataAnnotations;

namespace Pioneers.Core.Models;

public class DropdownOption
{
    public int Id { get; set; }

    [Required]
    public string Value { get; set; }

    public int CustomPropertyId { get; set; }

    public CustomProperty EmployeeProperty { get; set; }
}