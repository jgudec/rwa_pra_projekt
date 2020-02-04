using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicSite.Models.ViewModels
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "Morate unijeti korisničko ime!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Morate unijeti lozinku!")]
        [DataType(DataType.Password)]
        [Display(Name = "Zaporka")]
        public string Password { get; set; }
    }
}