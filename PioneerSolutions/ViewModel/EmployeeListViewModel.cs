namespace PioneerSolutions.ViewModel
{
    public class EmployeeListViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> CustomProperties { get; set; } = new Dictionary<string, string>();

    }
}
