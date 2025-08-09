using System.ComponentModel.DataAnnotations;

namespace PioneerSolutions.ViewModel
{
    public class CreateEmployeeViewModel
    {
        [Required(ErrorMessage = "Employee code is required")]
        [Display(Name = "Employee Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Employee name is required")]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }

        public List<CustomPropertyInputViewModel> CustomProperties { get; set; } = new List<CustomPropertyInputViewModel>();

    }
}
