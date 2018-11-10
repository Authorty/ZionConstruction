using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZionConstruction.Models
{
    public class ContactEmailModels
    {
        [MinLength(4, ErrorMessage = "Minimum of 4 charecters")]
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(7, ErrorMessage = "Please fill in 7 digits")]
        public string Phone { get; set; }

        [Required]
        public string Message { get; set; }
    }
}