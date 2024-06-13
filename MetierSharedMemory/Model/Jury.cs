using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetierSharedMemory.Model
{
    public class Jury : Personne
    {
        [MaxLength(20, ErrorMessage = "taille maximale 20"), Required(ErrorMessage = "*")]
        [Display(Name = "Grade membre jury")]
        public string Grade { get; set; }
        [MaxLength(50, ErrorMessage = "taille maximale 50"), Required(ErrorMessage = "*")]
        [Display(Name = "Specialite membre jury")]
        public string Specialite { get; set; }

        /*public virtual ICollection<Memoire> Memoires { get; set; }*/
    }
}