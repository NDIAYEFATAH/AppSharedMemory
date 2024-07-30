using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appsharedMemory.Service;
using appsharedMemory.Model;

namespace appsharedMemory
{
    public partial class frmCategorie : Form
    {
        CategorieService categorieService = new CategorieService();
        public frmCategorie()
        {
            InitializeComponent();
        }
       
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Categorie categorie = new Categorie();
            categorie.CodeCategorie = txtCode.Text;
            categorie.LibelleCategorie = txtLibelle.Text;
            if(string.IsNullOrEmpty(txtCode.Text) || string.IsNullOrEmpty(txtLibelle.Text))
            {
                MessageBox.Show("Tous les champs doivent être remplis.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                categorieService.AddProduit(categorie);
                effacer();
            }
        }

        private void frmCategorie_Load(object sender, EventArgs e)
        {
            dgCategorie.DataSource = categorieService.servGetListCategorie();
        }

        public void effacer()
        {
            txtCode.Clear();
            txtLibelle.Clear();
            dgCategorie.DataSource = categorieService.servGetListCategorie();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            txtCode.Text = dgCategorie.CurrentRow.Cells[1].Value.ToString();
            txtLibelle.Text = dgCategorie.CurrentRow.Cells[2].Value.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(dgCategorie.CurrentRow.Cells[0].Value.ToString(), out id) && id > 0)
            {
                if (string.IsNullOrEmpty(txtCode.Text) || string.IsNullOrEmpty(txtLibelle.Text))
                {
                    MessageBox.Show("Tous les champs doivent être remplis.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Categorie categorie = new Categorie
                {
                    idCategorie = id,
                    CodeCategorie = txtCode.Text,
                    LibelleCategorie = txtLibelle.Text
                };

                // Appelez le service pour mettre à jour la catégorie
                bool success = categorieService.UpdateProduit(categorie);

                // Affichez un message en fonction du résultat
                if (success)
                {
                    effacer();
                    MessageBox.Show("Catégorie modifiée avec succès.");
                }
                else
                {
                    MessageBox.Show("Échec de la mise à jour de la catégorie.");
                }
            }
            else
            {
                MessageBox.Show("Identifiant non trouvé ou invalide.");
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(dgCategorie.CurrentRow.Cells[0].Value.ToString(), out id) && id > 0)
            {
                if (string.IsNullOrEmpty(txtCode.Text) || string.IsNullOrEmpty(txtLibelle.Text))
                {
                    MessageBox.Show("Aucun element selectionner.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Categorie categorie = new Categorie { idCategorie = id };

                bool success = categorieService.DeleteCategorie(categorie);

                if (success)
                {
                    effacer();
                    MessageBox.Show("Catégorie supprimée avec succès.");
                }
                else
                {
                    MessageBox.Show("Échec de la suppression de la catégorie.");
                }
            }
            else
            {
                MessageBox.Show("Identifiant non trouvé ou invalide.");
            }
        }
    }
}
