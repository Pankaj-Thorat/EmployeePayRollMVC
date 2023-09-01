using System;
using System.ComponentModel.DataAnnotations;

namespace CommonLayer
{
    public class Employee
    {
        public int EmpId { get; set; }

        [Required(ErrorMessage ="{0} is required")]
        [StringLength(20,MinimumLength =2,ErrorMessage = "Name should be between 2 to 20 characters.")]
        public string EmpName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string ProfileImg { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Department { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "{0} should not be negative.")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50,MinimumLength =5, ErrorMessage = "Notes should be between 5 to 50 characters.")]
        public string Notes { get; set; }
    }
}
