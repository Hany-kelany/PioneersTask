using Pioneers.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace PioneerSolutions.ViewModel
{
    public class CustomPropertyViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Property name is required")]
        [Display(Name = "Property Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Property type is required")]
        [Display(Name = "Property Type")]
        public PropertyDataType Type { get; set; }

        [Display(Name = "Is Required")]
        public bool IsRequired { get; set; }

        [Display(Name = "Dropdown Options (comma separated)")]
        public string? DropdownOptionsText { get; set; }

        public List<DropdownOption> DropdownOptions { get; set; } = new List<DropdownOption>();

    }
}
