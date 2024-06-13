/*using fatt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fatt.utils
{
    public class LoadComboBox
    {
        dbKireneEntities db = new dbKireneEntities();
        

        public List<ListSelectedViewModel> LoadProfil()
        {
            List<ListSelectedViewModel> laliste = new List<ListSelectedViewModel>();
            laliste.Add(new ListSelectedViewModel
            {
                Value = null,
                Text = "Selectionner..."
            }) ;
            var liste = db.Profil.ToList();
            foreach (var p in liste)
            {
                laliste.Add(new ListSelectedViewModel
                {
                    Value = p.CodeProfile,
                    Text = p.LibelleProfile
                });
            }
            return laliste;
        }
    }
}
*/