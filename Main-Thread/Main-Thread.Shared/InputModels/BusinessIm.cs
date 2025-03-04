using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;    
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Main_Thread.Shared.InputModels
{
    public class BusinessIm
    {
        [Required]
        [StringLength(50, ErrorMessage = "First name must be under 50 characters.")]
        public string OwnerFirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name must be under 50 characters.")]
        public string OwnerLastName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

        [Required]
        [MaxLength(60)]
        public string BusinessName { get; set; }

        [Required]
        [Phone]
        [MaxLength(10)]
        public string ContactNumber { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required]
        [MinLength(9)]
        [MaxLength(9)]
        public string StateEntityRegistration { get; set; }

        [Required]
        [MinLength(9)]
        [MaxLength(9)]
        public string EmployerIdentificationNumber { get; set; }

        [Required]
        [MaxLength(60)]
        public string StreetAddressOne { get; set; }

        // Optional
        [MaxLength(60)]
        public string? StreetAddressTwo { get; set; }

        [Required]
        [MaxLength(30)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public string StateProvince { get; set; }
        
        [Required]
        [MinLength(5)]
        [MaxLength(5)]
        public string ZipCode { get; set; } 

        [Required]
        public string BusinessType { get; set; }

        // Optional
        [MaxLength(100)]
        public string? OtherBusinessType { get; set; }
    }
}
