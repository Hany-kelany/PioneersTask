namespace PioneerSolutions.ViewModel
{
    public class CustomPropertyInputViewModel
    {
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public bool IsRequired { get; set; }
        public string Value { get; set; }
        public List<string> DropdownOptions { get; set; } = new List<string>();

    }
}
