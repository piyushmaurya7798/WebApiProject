using System.ComponentModel.DataAnnotations;

namespace WebApiProject.Models
{
    public class Emp
    {
        [Key]
        public int Id { get; set; }
        public string? Pname { get; set; }

        public string? department { get; set; }
        public double Salary { get; set; }


    }
}
