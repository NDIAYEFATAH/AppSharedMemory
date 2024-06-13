using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetierSharedMemory.Model
{
    public class Memoire
    {
        [Key]
        public int IdMemoire { get; set; }


        [MaxLength(300, ErrorMessage = "taille maximale 300"), Required(ErrorMessage = "*")]
        [Display(Name = "Titre")]
        public string Titre { get; set; }


        [Required(ErrorMessage ="*")]
        public int Annee { get; set; }


        [MaxLength(10, ErrorMessage = "taille maximale 10")]
        [Display(Name = "Statut")]
        public string Statut { get; set; }


        [MaxLength(80, ErrorMessage = "taille maximale 80"), Required(ErrorMessage = "*")]
        [Display(Name = "Auteur")]
        public string Auteur { get; set; }


        [MaxLength(40, ErrorMessage = "taille maximale 40"), Required(ErrorMessage = "*")]
        [Display(Name = "Fichier")]
        public string FileName { get; set; }


        [MaxLength(10, ErrorMessage = "taille maximale 10"), Required(ErrorMessage = "*")]
        [Display(Name = "Extension")]
        public string Extension { get; set; }


        [MaxLength(20, ErrorMessage = "taille maximale 20"), Required(ErrorMessage = "*")]
        [Display(Name = "Fichier")]
        public string Mention { get; set; }


        [MaxLength(30, ErrorMessage = "taille maximale 30"), Required(ErrorMessage = "*")]
        [Display(Name = "Niveau")]
        public string Niveau { get; set; }


        [MaxLength(40, ErrorMessage = "taille maximale 40"), Required(ErrorMessage = "*")]
        [Display(Name = "Filiere")]
        public string Filiere { get; set; }


        [MaxLength(40, ErrorMessage = "taille maximale 40"), Required(ErrorMessage = "*")]
        [Display(Name = "Appreciation")]
        public string Appreciation { get; set; }


        [DataType(DataType.Date), Required(ErrorMessage = "*")]
        [Display(Name = "Date de publication")]
        public DateTime? DatePublication { get; set; }



        /*public virtual ICollection<Jury> Jury { get; set; }*/
    }
}