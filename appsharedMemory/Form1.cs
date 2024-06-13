using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using appsharedMemory.ServiceMetier;

namespace appsharedMemory
{
    public partial class Form1 : Form
    {
        ServiceMetier.Service1Client service = new ServiceMetier.Service1Client();
        public Form1()
        {
            service = new ServiceMetier.Service1Client();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgJury.DataSource = service.GetJurys();
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            ServiceMetier.Jury jury = new ServiceMetier.Jury();
            jury.Prenom = txtPrenom.Text;
            jury.Nom = txtNom.Text;
            jury.Grade = txtGrade.Text;
            jury.Specialite = txtSpecialite.Text;
            service.AddJury(jury);
            Effacer();
        }

        public void Effacer()
        {
            txtNom.Text = string.Empty;
            txtPrenom.Text = string.Empty;
            txtGrade.Text = string.Empty;
            txtSpecialite.Text = string.Empty;
            dgJury.DataSource = service.GetJurys();
            txtNom.Focus();
        }
    }
}
