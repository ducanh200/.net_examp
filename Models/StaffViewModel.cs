using System.ComponentModel.DataAnnotations;

namespace EXAMP.Models
{
    public class StaffViewModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int department_id { get; set; }
    }
}
