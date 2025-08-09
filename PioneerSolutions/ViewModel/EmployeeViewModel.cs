using System.ComponentModel.DataAnnotations;

namespace PioneerSolutions.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee code is required")]
        [Display(Name = "Employee Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        public List<PropertyValueViewModel> PropertyValues { get; set; } = new List<PropertyValueViewModel>();

    }
}
