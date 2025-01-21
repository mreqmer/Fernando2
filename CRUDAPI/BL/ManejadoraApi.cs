using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Newtonsoft.Json;

namespace BL
{
    public class ManejadoraApi
    {

        public static async Task<List<DTOPersona>> getPersonas()
        {
            //Pido la cadena de la Uri al método estático

            Uri miUri = new Uri("https://martaasp.azurewebsites.net/api/personas");
            List <DTOPersona> listaPersonas = new List<DTOPersona>();
            HttpClient mihttpClient;
            HttpResponseMessage miCodigoRespuesta;
            string textoJsonRespuesta;
            DTOPersona response = new DTOPersona();
            //Instanciamos el cliente Http
            mihttpClient = new HttpClient();
            try
            {
                miCodigoRespuesta = await mihttpClient.GetAsync(miUri);
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);
                    mihttpClient.Dispose();
                    listaPersonas = JsonConvert.DeserializeObject<List<DTOPersona>>(textoJsonRespuesta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaPersonas;
        }

        public static async Task<DTOPersona> getPersona(int idPersona)
        {
            //Pido la cadena de la Uri al método estático

            Uri miUri = new Uri("https://martaasp.azurewebsites.net/api/personas/" + idPersona);
            DTOPersona persona = new DTOPersona();
            HttpClient mihttpClient;
            HttpResponseMessage miCodigoRespuesta;
            string textoJsonRespuesta;
            DTOPersona response = new DTOPersona();
            //Instanciamos el cliente Http
            mihttpClient = new HttpClient();
            try
            {
                miCodigoRespuesta = await mihttpClient.GetAsync(miUri);
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);
                    mihttpClient.Dispose();
                    persona = JsonConvert.DeserializeObject<DTOPersona>(textoJsonRespuesta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return persona;
        }

        public static async Task<bool> deletePersona(int idPersona)
        {
            //Pido la cadena de la Uri al método estático
            bool esBorrado = false;
            Uri miUri = new Uri("https://martaasp.azurewebsites.net/api/personas/" + idPersona);
            DTOPersona persona = new DTOPersona();
            HttpClient mihttpClient;
            HttpResponseMessage miCodigoRespuesta;
            string textoJsonRespuesta;
            DTOPersona response = new DTOPersona();
            //Instanciamos el cliente Http
            mihttpClient = new HttpClient();
            try
            {
                miCodigoRespuesta = await mihttpClient.DeleteAsync(miUri);
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    esBorrado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return esBorrado;
        }

    }
}
