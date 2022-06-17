using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudOperationApplication.Models
{
    public class Employee
    {
        [Key]
        public int empid { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name")]
        [Display(Name = "Employee Name")]
        public string empname { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public int empphoneno { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please enter Email ID")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string email { get; set; }

        public string empdesignation { get; set; }

        public DateTime createDate { get; set; }

        public DateTime lastUpdated { get; set; }

        public bool isActive { get; set; }

    }
}