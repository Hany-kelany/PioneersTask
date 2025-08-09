using System.ComponentModel.DataAnnotations;

namespace Pioneers.Core.Models;

public class CustomProperty : BaseEntity
{
    [Required]
    public string Name { get; set; }
    public PropertyDataType Type { get; set; }
    public bool IsRequired { get; set; }
    public string? DropListOptions { get; set; } 
    public ICollection<DropdownOption> DropdownOptions { get; set; } = new List<DropdownOption>();

}
