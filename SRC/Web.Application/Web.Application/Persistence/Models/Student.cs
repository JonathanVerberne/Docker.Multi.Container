using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Application.Persistence.Models
{
    [Table("student")]
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string EnrollmentDate { get; set; }
    }
}
