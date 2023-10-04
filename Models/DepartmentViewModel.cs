using System;
using System.ComponentModel.DataAnnotations;
namespace EXAMP.Models
{
    public class DepartmentViewModel
    {
        [Required(ErrorMessage = "Vui Lòng nhập tên danh mục")]
        [MinLength(6, ErrorMessage = "Vui lòng nhập tối thiếu 6 kí tự")]
        [Display(Name = "Tên danh mục")]
        public string name { get; set; }
    }
}
