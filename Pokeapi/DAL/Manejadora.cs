using DTO;
using ENT;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;
namespace DAL
{
    public class Manejadora
    {

        public static string urlInicial()
        {
            string miCadenaUrl = "https://pokeapi.co/api/v2/";
            return miCadenaUrl;
        }

        public static async Task<CosasPokemon> getPokemon(int cantidadPokemon)
        {
        //Pido la cadena de la Uri al método estático
        
            Uri miUri = new Uri($"{urlInicial()}pokemon?offset=0&limit={cantidadPokemon}");
            List<ClsPokemon> listadoPokemon = new List<ClsPokemon>();
            HttpClient mihttpClient;
            HttpResponseMessage miCodigoRespuesta;
            string textoJsonRespuesta;
            CosasPokemon response = new CosasPokemon();
            //Instanciamos el cliente Http
            mihttpClient = new HttpClient();
            try
            {
                miCodigoRespuesta = await mihttpClient.GetAsync(miUri);
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);
                    mihttpClient.Dispose();
                    response = JsonConvert.DeserializeObject<CosasPokemon>(textoJsonRespuesta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public static async Task<CosasPokemon> getPokemon(string url)
        {
            //Pido la cadena de la Uri al método estático

            Uri miUri = new Uri($"{url}");
            List<ClsPokemon> listadoPokemon = new List<ClsPokemon>();
            HttpClient mihttpClient;
            HttpResponseMessage miCodigoRespuesta;
            string textoJsonRespuesta;
            CosasPokemon response = new CosasPokemon();
            //Instanciamos el cliente Http
            mihttpClient = new HttpClient();
            try
            {
                miCodigoRespuesta = await mihttpClient.GetAsync(miUri);
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);
                    mihttpClient.Dispose();
                    response = JsonConvert.DeserializeObject<CosasPokemon>(textoJsonRespuesta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public static async Task<string> getFoto(string url)
        {
            //Pido la cadena de la Uri al método estático

            Uri miUri = new Uri($"{urlInicial()}");
            string foto="";
            HttpClient mihttpClient;
            HttpResponseMessage miCodigoRespuesta;
            string textoJsonRespuesta;
            CosasPokemon response = new CosasPokemon();
            //Instanciamos el cliente Http
            mihttpClient = new HttpClient();
            try
            {
                miCodigoRespuesta = await mihttpClient.GetAsync(miUri);
                if (miCodigoRespuesta.IsSuccessStatusCode)
                {
                    textoJsonRespuesta = await mihttpClient.GetStringAsync(miUri);
                    mihttpClient.Dispose();
                    response = JsonConvert.DeserializeObject<CosasPokemon>(textoJsonRespuesta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return foto;
        }

    }

}

