using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXAMP.Entities
{
    [Table("staffs")]

    public class Staff
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(200)]
        public string name { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string email { get; set; }
        public int department_id { get; set; }
        [ForeignKey("department_id")]
        public Department Department { get; set; }
    }
}
