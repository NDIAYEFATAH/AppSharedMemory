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
using appsharedMemory.ServiceMetier;
using MetierSharedMemory;
using Newtonsoft.Json;

namespace appsharedMemory
{
    public partial class Form1 : Form
    {
        /*Service1Client serv;*/
        ServiceMetier.Service1Client service = new ServiceMetier.Service1Client();
        public Form1()
        {
            service = new ServiceMetier.Service1Client();
            /*serv = new Service1Client("BasicHttpBinding_IService1");*/
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*try
            {
                dgJury.DataSource = servGetListJury();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
            }*/

            dgJury.DataSource = service.GetJurys();
        }
        public List<Jury> servGetListJury()
        {
            HttpClient client;
            client = new HttpClient();
            var services = new List<Jury>();
            client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["ServeurApiUrl"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("appShared/values/GetListJury").Result;

            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                services = JsonConvert.DeserializeObject<List<Jury>>(responseData);
            }
            return services;
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
