using Pioneers.Core.Models;

namespace PioneerSolutions.ViewModel
{
    public class PropertyValueViewModel
    {
        public int CustomPropertyId { get; set; }
        public string PropertyName { get; set; }
        public PropertyDataType PropertyType { get; set; }
        public bool IsRequired { get; set; }
        public string Value { get; set; }
        public List<DropdownOption> DropdownOptions { get; set; } = new List<DropdownOption>();

    }
}
