using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MetierSharedMemory.Migrations;
using MetierSharedMemory.Model;
using MetierSharedMemory.utils;

namespace MetierSharedMemory
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        BdSharedMemoryContext db = new BdSharedMemoryContext();
        Logger log = new Logger();
        
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /// <summary>
        /// Cette fonction permet l'enregistrement d'un jury
        /// </summary>
        /// <param name="jury">membre jury</param>
        /// <returns>true si ok, sinon false</returns>
        public bool AddJury(Jury jury)
        {
            try
            {
                db.Jurys.Add(jury);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                log.WriteDataError("Service1-AddJury", ex.ToString());
                return false;
            }
        }


        /// <summary>
        /// Cette methode permet de modifier un jury
        /// </summary>
        /// <param name="jury">membre du jury</param>
        /// <returns>true si ok, sinon false</returns>
        public bool EditJury(Jury jury)
        {
            try
            {
                var lejury = db.Jurys.Find(jury.IdPersonne);
                if (lejury == null)
                {
                    lejury.Nom=jury.Nom;
                    lejury.Prenom=jury.Prenom;
                    lejury.Specialite=jury.Specialite;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.WriteDataError("Service1-EditJury", ex.ToString());
                return false;
            }
            return false;
        }


        /// <summary>
        /// Cette methode permet de supprimer un jury
        /// </summary>
        /// <param name="juryId"></param>
        /// <returns></returns>
        public bool DeleteJury(int? juryId)
        {
            try
            {
                var lejury = db.Jurys.Find(juryId);
                if (lejury == null)
                {
                    db.Jurys.Remove(lejury);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) 
            {
                log.WriteDataError("Service1-DeleteJury", ex.ToString());
                return false;
            }
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Jury> GetJurys()
        {
            return db.Jurys.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Jury> GetJury(string Nom, string Prenom, string Specialite)
        {
            var liste = db.Jurys.ToList();
            if (!string.IsNullOrEmpty(Nom))
            {
                liste = liste.Where(a=> a.Nom.ToUpper().Contains(Nom.ToUpper())).ToList();
            }
            if (!string.IsNullOrEmpty(Prenom))
            {
                liste = liste.Where(a => a.Prenom.ToUpper().Contains(Prenom.ToUpper())).ToList();
            }
            if (!string.IsNullOrEmpty(Specialite))
            {
                liste = liste.Where(a => a.Specialite.ToUpper().Contains(Specialite.ToUpper())).ToList();
            }

            return liste;
        }
    }
}
