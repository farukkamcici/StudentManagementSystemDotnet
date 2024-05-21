using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class StudentDto
    {
        public int Id { get; set; }

        [Required,MaxLength(64)]
        public string Name { get; set; }

        public int ClassId { get; set; }
        
    }
}
