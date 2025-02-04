using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ClsMensajeUsuario
    {
        private string nombreUsuario;
        private string mensajeUsuario;
        private string grupo;

        public string NombreUsuario { get { return nombreUsuario; } set { nombreUsuario = value; } }
        public string MensajeUsuario { get { return mensajeUsuario; } set { mensajeUsuario = value; } }
        public string Grupo { get { return grupo; } set { grupo = value; } }
    
        public ClsMensajeUsuario()
        {
        }

        public ClsMensajeUsuario(string nombreUsuario, string mensajeUsuario, string grupo)
        {
            this.nombreUsuario = nombreUsuario;
            this.mensajeUsuario = mensajeUsuario;
            this.grupo = grupo;
            
        }
    }
}
