using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CORE_DB.Models
{
    public partial class ItEmpDetail
    {
      
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Enter Employee Name")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Name must consist of minimum 4 characters")]
        [RegularExpression(@"^([A-Za-z]+)$")]
        public string EmployeeName { get; set; } = null!;

        [Required]
        public int? EmployeeSal { get; set; }

        [Required]
        public DateTime? Doj { get; set; }
    }
}
