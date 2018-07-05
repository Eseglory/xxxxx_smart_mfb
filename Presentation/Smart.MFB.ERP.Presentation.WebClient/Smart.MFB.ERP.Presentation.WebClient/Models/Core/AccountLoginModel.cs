using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Smart.MFB.ERP.Presentation.WebClient.Models
{
    public class AccountLoginModel
    {
        [Required]
        [EmailAddress]
        public string LoginID { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}