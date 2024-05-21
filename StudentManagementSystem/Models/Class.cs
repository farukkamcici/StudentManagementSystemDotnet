using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Class
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(1)]
        public string ClassName { get; set; }

    }
}
