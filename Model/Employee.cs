using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperOrmDemo.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required (AllowEmptyStrings = false, ErrorMessage = "Please enter full name")]
        public string FullName { get; set; }
        public DateTime DateofBirth { get; set; }
        [Required(ErrorMessage = "Please enter mobile no")] 
        [StringLength(10, ErrorMessage = "The mobile must contains 10 characters", MinimumLength = 10)] 
        public string ContactNo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter pan no")]
        public string PanNo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter aadhar no")]
        public string AadharNo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter address")]
        public string Address { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter salary")]
        public double Salary { get; set; }

        public string DepartmentName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter department id")]
        public int DepartmentId { get; set; }

    }
}
