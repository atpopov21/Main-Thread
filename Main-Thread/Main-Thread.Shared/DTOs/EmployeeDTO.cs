using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_Thread.Shared.DTOs
{
    public class EmployeeDTO
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(60)]
        public string Email { get; set; }

        [Required]
        [MaxLength(10)]
        public string ContactNumber { get; set; }

        [Required]
        [MaxLength(20)]
        public DateTime HireDate { get; set; }

        [MaxLength(1)]
        public double? Rating { get; set; }

        [Required]
        [MaxLength(2)]
        public int Role{ get; set; }
    }
}
