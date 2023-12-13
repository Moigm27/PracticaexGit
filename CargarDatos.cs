using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practicaex
{
    public class CargarDatos
    {
        string firstName;
        string lastName;
        public string ConsultarAPI(int cedula)
        {
            using (HttpClient cliente = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = cliente.GetAsync("https://apis.gometa.org/cedulas/" + cedula).Result;
                    response.EnsureSuccessStatusCode();

                    string jsonResponse = response.Content.ReadAsStringAsync().Result;

                    // Deserializar el JSON a un objeto anónimo
                    var jsonObject = JsonConvert.DeserializeAnonymousType(
                        jsonResponse,
                        new { results = new[] { new { firstname = "", lastname = "" } } }
                    );

                    // Acceder a los campos firstname y lastname
                    firstName = jsonObject.results[0].firstname;
                    lastName = jsonObject.results[0].lastname;

                    // Imprimir los resultados
                    MessageBox.Show("Firstname: " + firstName);
                    MessageBox.Show("Lastname: " + lastName);
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción aquí si es necesario
                    MessageBox.Show("Error al consultar la API: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return firstName + " " + lastName;
            }

        }
    }
}
