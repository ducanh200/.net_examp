using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EXAMP.Entities
{
    [Table("departments")]

    public class Department
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public ICollection<Staff> staffs { get; set; }
    }
}
