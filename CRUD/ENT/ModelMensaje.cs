using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ModelMensaje
    {

        private string grupo;
        private string nombreUsuario;
        private string mensaje;

        public string Grupo { get { return grupo; } set { grupo = value; } }
        public string NombreUsuario { get { return nombreUsuario; } set { nombreUsuario = value; } }
        public string Mensaje { get { return mensaje; } set { mensaje = value; } }



    }
}
