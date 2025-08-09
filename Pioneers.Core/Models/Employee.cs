using System.ComponentModel.DataAnnotations;

namespace Pioneers.Core.Models; 
public class Employee :BaseEntity
{
    [Required]
    public string Code { get; set; }
    [Required]
    public string  Name { get; set; }
    public ICollection<EmployeePropertyValue> PropertyValues { get; set; } = new List<EmployeePropertyValue>();

}
