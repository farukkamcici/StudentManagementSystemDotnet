using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Models
{
    public class Student
    {
        [Required(ErrorMessage = "The class ID field is required.")]
        public int Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }

        [ForeignKey("Class")]
        [Required(ErrorMessage = "The class ID field is required.")]
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
