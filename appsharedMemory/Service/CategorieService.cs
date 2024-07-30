using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using appsharedMemory.Model;
using Newtonsoft.Json;

namespace appsharedMemory.Service
{
    public class CategorieService
    {
        /// <summary>
        /// Cette fonction retourne laliste des categories
        /// </summary>
        /// <returns>retourne la liste des categories</returns>
        public List<Categorie> servGetListCategorie()
        {
            HttpClient client;
            client = new HttpClient();
            var services = new List<Categorie>();
            client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["ServeurApiURL"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync("api.php/categories").Result;

            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                services = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Categorie>>(responseData);
            }
            return services;
        }
        /// <summary>
        /// Cette methode permet d'ajouter une categorie
        /// </summary>
        /// <param name="emp">L'objet Categorie contenant l'ID de la catégorie à ajouter.</param>
        /// <returns>True si l'ajout a réussi, sinon False.</returns>
        public bool AddProduit(Categorie emp)
        {
            bool rep = false;
            var values = new
            {
                CodeCategorie = emp.CodeCategorie,
                LibelleCategorie = emp.LibelleCategorie
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(values), System.Text.Encoding.UTF8, "application/json");

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["ServeurApiURL"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.PostAsync("api.php/categories", jsonContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return rep;
        }
        /// <summary>
        /// Cette methode permet de modifier une categorie
        /// </summary>
        /// <param name="emp">L'objet Categorie contenant l'ID de la catégorie à modifier.</param>
        /// <returns>True si la modification a réussi, sinon False.</returns>
        public bool UpdateProduit(Categorie emp)
        {
            bool rep = false;

            if (emp.idCategorie <= 0)
            {
                Console.WriteLine("ID de catégorie invalide.");
                return rep;
            }

            var values = new
            {
                CodeCategorie = emp.CodeCategorie,
                LibelleCategorie = emp.LibelleCategorie
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(values), System.Text.Encoding.UTF8, "application/json");

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["ServeurApiURL"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var requestUri = $"api.php/categories/{emp.idCategorie}";
                    var response = client.PutAsync(requestUri, jsonContent).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                    else
                    {
                        Console.WriteLine($"Erreur: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return rep;
        }

        /// <summary>
        /// Cette methode permet de Supprimer une categorie
        /// </summary>
        /// <param name="emp">L'objet Categorie contenant l'ID de la catégorie à supprimer.</param>
        /// <returns>True si la suppression a réussi, sinon False.</returns>
        public bool DeleteCategorie(Categorie categorie)
        {
            bool rep = false;

            if (categorie.idCategorie <= 0)
            {
                Console.WriteLine("ID de catégorie invalide.");
                return rep;
            }

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(System.Configuration.ConfigurationSettings.AppSettings["ServeurApiURL"]);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Construire l'URL de la requête DELETE
                    var requestUri = $"api.php/categories/{categorie.idCategorie}";
                    var response = client.DeleteAsync(requestUri).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        rep = true;
                    }
                    else
                    {
                        // Affichez un message d'erreur détaillé
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Affichez un message d'exception détaillé
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return rep;
        }
    }
}
