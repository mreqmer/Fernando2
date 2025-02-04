using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class ClsPokemon
    {

        #region Atributos

        private int dex;
        private string nombre;
        private string foto;
        private string description;
        private int grupoHuevo;

        #endregion

        #region Propiedades

        public int Dex { get { return dex; }set { dex = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Foto { get { return foto; } set { foto = value; } }
        public string Description { get { return description; } set { description = value; } }
        public int GrupoHuevo { get { return grupoHuevo; } set { grupoHuevo = value; } }

        #endregion

        #region Constructores

        public ClsPokemon()
        {

        }

        public ClsPokemon(int dex, string nombre, string foto, string description, int grupoHuevo)
        {
            this.dex = dex;
            this.nombre = nombre;
            this.foto = foto;
            this.description = description;
            this.grupoHuevo=grupoHuevo;
        }



        #endregion

    }
}
