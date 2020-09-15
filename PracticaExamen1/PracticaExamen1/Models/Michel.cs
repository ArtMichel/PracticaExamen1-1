using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticaExamen1.Models
{
    public enum CategoryType
    {
        Zoologico = 1,
        Centro = 2,
        Plaza = 3,
        Ventura = 4,
        Urubo = 5
    }
    public class Michel
    {
        [Key]
        public int MichelID { get; set; }
        [Required]
        [Display(Name = "Nombre Completo")]
        [StringLength(30, ErrorMessage = "El campo {0} debe contener entre {2} y {1} caracteres", MinimumLength = 2)]
        public string FriendofMichel { get; set; }
        [Required]
        public CategoryType Place { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Cumpleaños")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
    }
}