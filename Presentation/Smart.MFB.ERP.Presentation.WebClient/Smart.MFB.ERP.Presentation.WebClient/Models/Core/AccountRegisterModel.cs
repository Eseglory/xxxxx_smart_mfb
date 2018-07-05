using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Smart.MFB.ERP.Presentation.WebClient.Models
{
    public class AccountRegisterModel
    {
        [Required]
        [EmailAddress]
        public string LoginID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }

        [Required]
        [EmailAddress]
        [Compare("LoginID")]
        public string Email { get; set; }
    }
}
