using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicSite.Models.ViewModels
{
    public class RegistrationViewModel
    {
        public int IDKorisnik { get; set; }

        [Required(ErrorMessage = "Molimo ispunite polje!")]
        [Display(Name = "KorisnickoIme")]
        [DefaultValue("User")]
        public string KorisnickoIme { get; set; }

        [Required(ErrorMessage = "Molimo ispunite polje!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Molimo ispunite polje!")]
        [DataType(DataType.Password)]
        [StringLength(int.MaxValue, ErrorMessage = "Character length of {0} must be at least {2}.", MinimumLength = 8)]
        public string Lozinka { get; set; }



        [Required(ErrorMessage = "Polje je obavezno")]
        [Display(Name = "Ime")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [Display(Name = "Prezime")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [Display(Name = "Datum rođenja")]
		[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DefaultValue(true)]
        public DateTime DOB { get; set; }


        [Display(Name = "Spol")]
        [Required(ErrorMessage = "Obavezan odabir")]
        public char Spol { get; set; }

        public int TipDijabetesa { get; set; }

        public int FizickaAktivnost { get; set; } = 1;

        [Required(ErrorMessage = "Polje je obavezno")]
        [Display(Name = "Visina(cm)")]
        [Range(125, 230)]
        public double Visina { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [Display(Name = "Težina(kg)")]
        [Range(30, 300)]
        public double Tezina { get; set; }

        public double BMI { get; set; }



    }
}