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
    public class RegisterCompanyIM
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(60)]
        public string Password { get; set; }

        [Required]
        [MaxLength(60)]
        public string BusinessName { get; set; }

        [Required]
        [Phone]
        [MaxLength(10)]
        public string ContactNumber { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(40)]
        public string Email { get; set; }

        [Required]
        [MaxLength(10)]
        public string StateEntityRegistration { get; set; }

        [Required]
        [MaxLength(10)]
        public string EmployerIdentificationNumber { get; set; }

        [Required]
        [MaxLength(60)]
        public string StreetAddressOne { get; set; }

        // Optional
        [MaxLength(60)]
        public string? StreetAddressTwo { get; set; }

        [Required]
        [MaxLength(20)]
        public string City { get; set; }

        [Required]
        [MaxLength(20)]
        public string StateProvince { get; set; }

        [Required]
        [MaxLength(5)]
        public string ZipCode { get; set; }

        [Required]
        public string BusinessType { get; set; }

        // Optional
        [MaxLength(60)]
        public string? OtherBusinessType { get; set; }
    }
}
